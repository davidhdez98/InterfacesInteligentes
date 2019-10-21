# Físicas en Unity

En esta práctica comenzaremos a aplicar física a los objetos de nuestro proyecto. De esta forma, con ayuda de los scripts, moveremos objetos con el motor de física de Unity, en lugar de modificando el componente _transform_. También realizaremos colisiones entre objetos, de modo que epxlicaremos los conceptos de **collider** y **trigger**.
# Creación de objetos con Rigidbody
Lo primero que haremos es crear el terreno y los objetos que necesitaremos, del mismo modo que hemos hecho en prácticas anteriores. Añadimos como GameObjects tres esferas; una de ellas va a actuar como nuestro jugador, que controlaremos a través del teclado. Las otras dos, en cambio, funcionarán como obstáculos que podrán chocar contra el jugador. A la hora de crearlos, debemos añadir, al menos al jugador, el componente **Rigidbody**, para que este responda a la física. A las otras esferas también podemos añadirles este componente, pero no es necesario. Con Rigidbody, los objetos seguirán las leyes físicas: tendrán gravedad y, si un objeto choca contra ellos, se desplazarán en consecuencia. Sin embargo, estas opciones se pueden modificar; podemos quitarle la gravedad al objeto, de modo que no caiga si se encuentra en el aire. Todo objeto con Rigidbody tiene una opción, _is kinematic_, que por defecto no está activa; si se aplica esta opción, al objeto no se le aplica física, es decir, actúa como si no se le hubiera aplicado un Rigidbody. 
En nuestro caso, aplicaremos física a las tres esferas, pero en una de ellas aplicaremos estas dos opciones (_is kinematic_ y no usar gravedad), de modo que no tenga ningún comportamiento físico ni se mueva. Así obtenemos, como se indica en el enunciado, una esfera fija.

FALTA LA QUE MUEVES CON TECLADO

# Colisiones

Todas las esferas que hemos creado, tengan o no aplicado un Rigidbody, poseen un **collider**, que se ha creado por defecto. Un collider es un sensor que rodea el objeto, que detecta si ese objeto ha chocado con otro. En el caso de las esferas, el collider tiene forma esférica y se denomina _Sphere collider_; los cubos, en cambio, poseen un _box collider_. Estos colliders tienen la forma del objeto al que rodean; por ello, vienen implícitos cuando creamos un objeto tan sencillo. Sin embargo, si nuestro objeto es una persona, no hay un _person collider_ implícito, sino algún collider que se ajuste lo máximo posible al objeto. Además, todos los objetos nos dan la posibilidad de editar este collider, de modo que lo agrandemos o lo movamos, y podemos incluso añadir más colliders sobre ese mismo objeto. 
En nuestro caso, lo que queremos hacer es que se detecte cualquier colisión que haya entre nuestro jugador y cualquiera de las otras dos esferas, y se incremente un contador. Para detectar una colisión, al menos uno de los dos objetos que colisionan debe ser un Rigidbody; sin embargo, es indispensable que **ambos objetos** tengan un collider. No hará falta que añadamos colliders a estos objetos ya que, como hemos dicho, viene ya creados por defectos, y tampoco los vamos a modificar. 

# Primer script: aleatorio.cs

Una de las dos esferas obstáculo debe permanecer inmóvil en la escena, como hemos visto anteriormente. Sin embargo, la otra debe moverse aleatoriamente por la escena. Para conseguir esto, creamos un script, _aleatorio.cs_ y lo aplicamos sobre esa esfera. A continuación, creamos la función _FixedUpdate()_. Esta función utiliza variables definidas anteriormente para calcular un nuevo camino que tomará la esfera. Los valores de estas variables se van actualizando, de modo que siempre se genera un movimiento nuevo. Además, modificamos el camino para que siempre se apliquen cambios en las coordenadas x y z, ya que no queremos que la esfera salga volando. Por último, aplicamos ese nuevo camino generado, llamando a la función _MovePosition_, que calcula la nueva posición sumando la actual con la que acabamos de calcular. El código está adjunto en InterfacesInteligentes/Practica03/aleatorio.cs .

# Segundo script: fisica.cs

En este segundo script contaremos el número de colisiones que sufre nuestro jugador. Para ello, declaramos como variable pública un contador, _choques_, y un objeto de tipo Rigibody, _rb_. En la función _start_, inicializamos estas dos variables. A continuación, modificaremos una función que viene dada en Unity, **OnCollisionEnter**. 

                                  private void OnCollisionEnter(Collision collision)
                                  {
                                        if (collision.gameObject.tag == "Obstaculo")
                                        {
                                              choques = choques + 1;    
            
                                        } 
                                   }
                                  
Esta función es llamada automáticamente cuando el collider del objeto detecta una colisión; intruducimos dentro el incremento del contador, de modo que cada vez que haya un choque, la función es invocada, pero el contador solo se incrementa cuando el choque se ha producido contra un objeto etiquetado como obstáculo. No existen más obstáculos que las dos esferas; sin embargo, ponemos el _if_ para que el contador no se incremente cuando el jugador choque contra el suelo. Hay que dejar claro que este script está añadido sobre el objeto jugador. Por ello, el parámetro _collision_ es el collider del objeto con el que choca el jugador, no el del objeto invocante. Por eso, en el _if_ se comprueba que la etiqueta de ese collider sea _Obstáculo_; si habláramos del objeto invocante, su etiqueta sería _Player_.

# Creación de cilindros

En esta siguiente punto de la práctica, lo que debemos hacer es crear cilindros que actúen como sensores. Para ello, añadimos un nueva GameObject cilindro. Este cilindro tendrá un color blanco; esto es importante, ya que en el siguiente script modificaremos este color varias veces. Creamos unos cuantos, y los colocamos alrededor de las esferas. A continuación, lo que vamos a hacer es agregar a cada uno de ellos un nuevo collider. La razón de ello la explicaremos más adelante, cuando creemos el siguiente script. Ahora, cada uno de los cilindros tiene 2 colliders, el que le viene por defecto (_capsule collider_) y el nuevo que le añadimos (_box collider_). Modificamos este nuevo colider, de modo que sus cuatro lados se salgan del cilindro. Con esto, lo que vamos a conseguir es que el programa detecte una colisión cuando todavía no se ha chocado la esfera con el cilindro, pero está próxima a chocarse. Así, más adelante podremos hacer que el cilindro cambie de color cuando una esfera está cerca (como se indica en el enunciado). Sin embargo, tal y como lo tenemos puesto ahora, si una esfera se acerca a un cilindro, no llegará a chocar con él; se encuentra primero el collider extra que añadimos, unos centímetros más adelantado que el otro collider. Para evitar esto, en el nuevo collider de cada cilindro seleccionamos la opción _is trigger_. Con esto, lo que conseguimos es que el sistema, aunque detecte la colisión, la ignore. Es decir, aunque la esfera choque con el collider extra, no se va a detener. Sin embargo, sí que se detecta la colisión. Ahora, procederemos a crear el script.

# Tercer script: sensores.cs

Con este script modificaremos el color de los cilindros, de modo que si una esfera entra en colisión con un cilindro, este cambia su color a amarillo; si permanece en colisión, pasa a naranja. Y cuando abandona la colisión, pasa a rojo. Por último, pasados unos segundos desde que terminó la colisión, el cilindro recuperará su color blanco inicial. 


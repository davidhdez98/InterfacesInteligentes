# Delegados y eventos

En esta práctica llevaremos a cabo la implementación de los delegados y eventos en Unity. Un delegado es básicamente un puntero a una función; esto permite utilizar métodos como si fueran variables. Un evento es un tipo de delegado, que se encarga de notificar a otras clases de un suceso en concreto. Los objetos interesados en un evento pueden suscribirse a él, o llamarlo cuando sucede el evento. El objetivo de esta práctica es simple: crearemos un objeto _jugador_, y dos tipos de objetos _obstáculo_. Dependiendo del tipo de obstáculo con el que el jugador se choque, lanzaremos un evento determinado, que llevará a cabo una acción en concreto.

# Creación de GameObjects

Lo primero que hacemos es crear dos GameObjects, uno de ellos un cilindro y el otro un cubo; etiquetamos a ambos objetos de forma distinta, de modo que podamos diferenciar dos tipos diferentes de objeto. Estos serán los obstáculos del jugador. Por otro lado, crearemos un GameObject etiquetado como _jugador_. En este caso, este jugador será una esfera. Para poder moverlo, le añadimos un _rigidbody_, e implementamos el siguiente script.

# Primer script: fisica.cs

  Tal y como hemos hecho en prácticas anteriores, creamos y añadimos un script en el objeto _jugador_, que implementará el código necesario para mover el objeto con los cursores. Asimismo, en esta ocasión hemos añadido una nueva opción; si se preciona la barra espaciadora, el jugador volverá a la posición inicial de la que partió. Hacemos esto con el fin de facilitar las pruebas de visualización, evitando detener la simulación cada vez que la esfera se nos sale del plano. En este fichero realizaremos, además, dos nuevos métodos, pero los explicaremos posteriormente.
  
# Segundo script: DelegateHandler.cs

Este es el script principal de nuestro proyecto. Tal y como se especifica en el enunciado de la práctica, se diferencian dos acciones posibles, según el jugador choque con el objeto de tipo A o el de tipo B. Es por ello que vamos a crear dos eventos y no uno. Lo que haremos será crear un delegado y dos eventos de tipo delegado, de esta forma:

                                      public delegate void ButtonClick();
                                      public static event ButtonClick Click;
                                      public static event ButtonClick Click2;
                                      
Una vez creados los eventos, deberemos lanzarlos en algún punto de nuestro programa. En nuestro caso, nos interesa que le active el evento cuando se produce una colisión con un objeto, de modo que implementaremos la función **OnCollisionEnter**. Asimismo, comprobaremos que el objeto con el que se choca es del tipo A; en ese caso, lanzamos el primer evento: **Click();**. Si, por el contrario, el collider que detecta esta función es el de un objeto de tipo B, se lanza el otro evento: **Click2();**. Como queremos que se detecten las colisiones que sufre el jugador, este script lo añadimos al objeto jugador.

# Modificación del primer script

Tal y como especificamos antes, en el script _fisica.cs_ hemos de añadir dos nuevos métodos, _Incrementar_Poder_ y _Decrementar_Poder_. Cada una de ellas será llamada por un evento distinto; si el jugador choca contra un objeto de tipo A, el evento _Click()_ llamará a la función _Incrementar_Poder_, que se encargará de incrementar la variable pública _poder_ en una unidad. Si el jugador choca con un objeto de tipo B, el evento _Click2()_ llamará a la función _Decrementar_Poder_, que decrementará la variable _poder_ en una unidad. 

Por otro lado, para que esto funcione correctamente, debemos suscribirnos a estos eventos; si no, estos no podrían llamar a estas nuevas funciones implementadas. Para suscribirse al evento, vamos a crear otros dos nuevos métodos en este script, de modo que finalmente habrá 4 métodos nuevos con respecto al inicio de la práctica. Estos métodos son **OnEnable** y **OnDisable**. Se trata de dos funciones del sistema que son llamadas cuando se habilita o deshabilita un objeto. En la primera nos suscribiremos al evento, mientras que en la segunda nos desuscribiremos. Es importante hacer ambas acciones, con el fin de evitar posibles errores en la ejecución del juego. Para suscribirnos y desuscribirnos, pondremos las siguientes líneas (cada una en su función correspondiente):

                                              DelegateHandler.Click += Incrementar_Poder;
                                              DelegateHandler.Click -= Incrementar_Poder;
                                              
Con estas instrucciones estamos llamando al evento _Click_ de la clase _DelegateHandler_. Cada vez que ocurra el evento (que, como hemos visto, ocurre al detectarse una colisión), la acción que se va a llevar a cabo vendrá determinada en la función _Incrementar_Poder_, creada anteriormente. Pero para establecer esta relación, era necesario suscribirse al evento. Haremos esta tarea con el segundo evento, que llamará a la función _Decrementar_Poder_.          

# Tercer script: Obstacle_B.cs

Como se indica en el enunciado, si el jugador choca contra un objeto de tipo B, no solo tendrá que decrementar su poder, sino que además el objeto de tipo B debe sufrir un cambio o transformación. Es por ello que vamos a crear un nuevo script, _Obstacle_B.cs_, que añadimos sobre el objeto de tipo B. Al igual que suscribimos al objeto jugador a los eventos, e implementamos las funciones llamadas por el evento, haremos lo mismo en este script. Primero, creamos los métodos _OnEnable()_ y OnDisable_, y suscribimos el evento. En este caso, solo será necesario suscribir el segundo evento. 

                                               DelegateHandler.Click2 += Cambiar_Color;
                                               
Ahora, implementaremos la función que es llamada por el evento, **Cambiar_Color**. Esta función se encargará de realizar la transformación del objeto de tipo B, que en este caso será cambiarle el color de forma aleatoria. Así, cada vez que el jugador choque con un objeto de tipo B, se lanzará el evento _Click2_; este evento llamará a los delegados de los objetos que estén suscritos a él. Por un lado, en la clase _física_ llamará a la función especificada para decrementar el poder del jugador. Por otro lado, en la clase _Obstacle_B_ llamará a esta nueva función implementada, _Cambiar_Color_, que generará un color aleatorio y se lo cambiará al objeto. En este caso es cuando resulta más útil la utilización de eventos, ya que queremos que cuando suceda una cosa (colisión) esto provoque dos acciones distintas, cada una en un objeto distinto. 

# Creación de más objetos

La idea principal es que haya varios objetos en la escena, que sirvan de obstáculos al jugador. Todos los que añadamos van a ser de tipo A o de tipo B; por eso solo hemos creado dos hasta ahora, uno de cada tipo. Lo que haremos a continuación es copiar y pegar varios objetos de cada tipo. Al ser copias, no solo tendrán la misma apariencia y características, sino que además tendrán los mismos scripts añadidos; es por ello que las acciones provocadas por un evento las sufrirán todos los objetos suscritos a ese evento, simultáneamente. Esto lo podremos comprobar en la simulación, ya que cuando el jugador choca con un objeto de tipo B, todos los objetos de ese tipo cambian de color, y no solo el que ha sufrido el contacto en concreto. Es importante aclarar que para que esto funcione no es necesario crear un script para cada objeto y suscribir ese objeto al evento; simplemente, al tener el mismo script añadido en todos los objetos, funciona correctamente. Sin embargo, en otra práctica sí sería conveniente añadir un nuevo script por cada objeto y suscribirlo al evento, siempre y cuando queramos que sucedan cosas distintas en cada uno de ellos. Pero en este caso, la acción implementada es la misma en todos ellos. Sí es cierto que, al generarse el color de forma aleatoria, todos los cilindros cambian de color pero no al mismo.

# Cuarto script: EncenderApagar.cs

Por último, queremos que durante la ejecución del juego se pueda encender y apagar un foco con el teclado. Para ello, crearemos un objeto de tipo **Light**, lo colocamos en la posición deseada y editamos sus características. En este caso, le hemos puesto color a la luz, y mayor intensidad, de modo que se note más la diferencia cuando se encienda y se apague. A continuación, creamos un script para implementar esta funcionalidad. Desarrollamos el código para que, cuando se presione la tecla **S**, se encienda el foco y cuando se presiona la tecla **N**, se apague.

A continuación se muestra un gif con el resultado final:

![Gift](https://github.com/davidhdez98/InterfacesInteligentes/blob/master/Practica04/Gif.gif)




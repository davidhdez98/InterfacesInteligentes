# Introducción a los scripts en Unity
En esta práctica vamos a realizar un script para poder mover un Game Object, pero sin utilizar física; simplemente accediendo a los métodos del componente **transform**. 
# Creación del terreno y el cubo
Lo primero que hacemos es crear un terreno, que será el suelo sobre el que se moverá nuestro objeto. A continuación, añadimos un Game Object cualquiera, en este caso un cubo, y lo colocamos sobre el terreno. Le aplicamos a cada objeto las texturas y materiales que queramos. 
# Creación del script
Situándonos sobre el cubo, le damos a Add component < New Script, le ponemos un nombre y le damos a **Crear y añadir**. En este momento se ha creado un script; todo lo que programemos en él afectará únicamente al Game Object sobre el que actúa (el cubo). Si abrimos el script en Visual Studio veremos que se ha creado una estructura por defecto, en la que tenemos un método que hereda de MonoBehaviour; este método tendrá el mismo nombre que el que le pusimos al script cuando lo creamos. Dentro del método se crea por defecto la función **start()**, que solo se invoca una vez, al principio, y la función **update()**, que se invoca en cada frame, para actualizar el resultado. Debemos tener esto en cuenta a la hora de programar. 
# Movimiento del objeto
Para conseguir que el objeto se mueva, lo primero que hacemos es declarar una variable pública, _public float speed = 10f;_. Esta variable indica la velocidad con la que se va a mover el objeto. Al hacerla pública, esta variable se podrá modificar desde el inspector de objetos, incluso en tiempo de ejecución. A continuación, escribimos la siguiente instrucción, que explicaremos seguidamente:

                                transform.Translate(new Vector3(-1,0,0) * speed * Time.deltaTime);  
            
Para mover el objeto, han de modificarse los valores del componente **transform**, de ahí que lo utilicemos. Además, el programa ya entiende que se quiere acceder al transform del objeto sobre el que está aplicado el script, de modo que no es necesario especificar el objeto antes. El método que nos permite realizar el movimiento es el **translate**. Este solicita dos parámetros, la dirección hacia la que se mueve y la velocidad con que lo hace. Hay que aclarar que esto no siempre es así; hay distintas aplicaciones de esta función, con más o menos parámetros, pero en este caso utilizaremos esta. Para indicar la posición hacia la que se mueve, creamos un vector de 3 coordenadas (Vector3), de modo que indiquemos con un valor distinto de 0 la posición hacia la que se mueve (en este caso, se mueve por el eje x en negativo). Si cambiamos los otros dos valores, se movería en todos los ejes. El otro parámetro calcula la velocidad que tendrá el movimiento, multiplicando la variable inicializada anteriormente con la función **Time.deltaTime**, que lo que hace es adaptarse al ordenador en concreto.      

  Haremos esta intrucción 4 veces, para poder moverlo hacia los lados y hacia delante y atrás (simplemente lo moveremos sobre el suelo, es decir, no tocaremos el eje Y). Por otro lado, para conseguir que el objeto se mueva cuando se pulse una determinada tecla, pondremos la siguiente instrucción, que está a la espera de que se pulse la flecha izquierda:        **if (Input.GetKey(KeyCode.LeftArrow) )**
# Rotación del objeto
Una vez realizado el código para las cuatro traslaciones posibles, pasamos a las rotaciones. En este caso, también realizaremos cuatro movimientos, con las flechas del teclado, pero pulsando al mismo tiempo la tecla **Shitt**. Por lo tanto, podemos reciclar parte del código, añadiendo una segunda condición en el _if_. En este caso usaremos la función **Rotate**. Hay que tener en cuenta que esta no es la única forma de rotar un objeto; también podemos hacer uso de la función **RotateAround**, o utilizar los **Quaternion**. Sin embargo, en este caso utilizaremos la primera opción, escribiendo esta instrucción:

                                  transform.Rotate(Vector3.left, speed * Time.deltaTime);
                                  
La sintaxis es casi igual que la función para trasladar, pero en este caso el resultado es distinto, ya que lo que conseguimos es que el objeto gire en distintas direcciones. Al igual que en la función anterior, podemos variar la velocidad del giro modificando el valor de la variable _speed_. En este caso utilizamos la misma variable que antes, pero si queremos que el objeto gire a una velocidad distinta de la que se traslada, haríamos lo mismo pero declarando una segunda variable pública. 

A continuación se muestra un gif en el que se observan los distintos movimientos que puede realizar el objeto:

![Gift](https://github.com/davidhdez98/InterfacesInteligentes/blob/master/Practica02/Gif.gif)
                                  





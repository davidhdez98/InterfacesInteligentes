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

Tal y como especificamos antes, en el script _fisica.cs_ hemos de añadir dos nuevos métodos. 

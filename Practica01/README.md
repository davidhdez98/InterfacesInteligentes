# Introducción a Unity
El objetivo principal de esta práctica es la familiarización con el entorno de trabajo Unity. Para ello, se han llevado a caso una serie de pasos que se explicarán a continuación. 
# Creación del terreno
El primer Game Object que he introducido es el terreno. Los valores de escala y posición son los predeterminados. A este objeto le ponemos la etiqueta **isla**. Lo primero que modificamos del terreno es la textura del mismo; para ello, vamos a Basic Terrain < Material, y cambiamos a la opción _custom_, para poder editar el terreno. Una vez seleccionada una textura, lo siguiente que he hecho ha sido simular unas monstañas, con la herramienta **Brush**. Con los parámetros de tamaño y altura adecuados, con esta herramienta conseguimos un efecto similar a un terreno montañoso y abrupto. 
# Creación de dos Game Objects
Como se especifica en el enunciado, he añadido dos esferas. Sin embargo, las he modificado de forma para que estén más alargadas, y las he bajado del plano, de forma que solo queda visible un semicírculo (la parte restante queda debajo del plano). Con este efecto, añadiéndole una textura adecuada, las dos esferas simulan dos rocas en el mar. Tienen como etiqueta **Piedra**. 
# Creación de un personaje de los Standard Assets (Ethan)
Sobre una de las dos rocas añadimos un personaje de los Standard Assets, **Ethan**, al que también modifico añadiéndole texturas. Hay que destacar que, al crear a Ethan, el objeto se divide automáticamente en esqueleto, cuerpo y gafas. De esta manera, cuando queramos añadirle una textura al objeto deberemos añadirla sobre alguna de estas tres subcategorías, de modo que modifiquemos solo el cuerpo de Ethan, o las gafas por ejemplo. Ethan tiene como etiqueta **player**.

# Creación de un personaje de la Asset Store
En este caso, no he añadido ningún personaje en concreto; lo que he hecho es descargar en la Asset Store diferentes Assets pero en los que hay texturas y objetos de la naturaleza. Con ellos, aunque no se aprecie a simple vista, he podido editar el terreno, aplicándole texturas de estos paquetes. Así mismo, he descargado otros paquetes de la Asset Store para ir probando diferentes cosas, pero finalmente no he aplicado los cambios. 

# Creación de árboles y agua
A partir de los Standard Assets podemos añadir el agua, que solo cubrirá parte del terreno, al haber diferentes alturas en el mismo. Se identifica con la etiqueta Mar. Del mismo modo, añadimos los árboles a partir de los Standard Assets. Si bien Unity nos da la opción de añadir un árbol desde el menú de Game Objects, añadirlo desde los Standard Assets no solo nos da un mejor resultado, sino que nos permite elegir entre distintos árboles, y añadirlos de una forma determinada. En mi caso, he añadido coníferas, utilizando la herramienta **Brush**. Es por ello que no se ha creado un objeto nuevo para los árboles, así que tampoco habrá etiquetas. Asimismo, cuando utilizo esta herramienta, no se crea solo un árbol, sino un conjunto de ellos; sin embargo, la herramienta da la opción de editar su funcionamiento, para que los árboles creados tengan un tamaño y una altura más o menos extensa. 

# Creación de dos focos de luz
Por último, he añadido una nueva fuente de luz adicional a la que ya viene por defecto. Rotando su posición, conseguimos que no se ilumine demasiado el terreno, dándole la luz justa y necesaria. 

![Gift](https://github.com/davidhdez98/InterfacesInteligentes/blob/master/Practica01/gift.gif)

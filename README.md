# README

## Qué es Console Pokemon?

Console Pokemon es un juego basado en Pokemon en el que dos jugadores escogen su pokemón preferido y ambos se baten a duelo, hasta que solo uno quede en pie.

---

## **Features**

### **Menus**

Hay diferentes Menus para cada etapa del programa:

- Inicio: Es el menú básico de inicio en el que el jugador escoge qué desea hacer.
- Ajustes: Es un menú ideado para que el jugador modifique la configuración del juego.
- In-game Menu: Es el menú de selección de ataques, mochila, información del pokemon, o huida.

Todos los menús están hechos de tal forma que el jugador puede escoger la opción deseada utilizando las teclas de arriba y abajo, y presionando enter.

---

## **Menus Functionality**

### **Main Menu**

Los menus están hechos en una clase especial `Menu.cs`, con dos funciones las cuales se encargan de toda la funcionalidad: `DisplayOptions` y `HandleKeyboard`.

`DisplayOptions` se encarga de mostrar las opciones disponibles para el usuario, las cuales se le pasan al objeto en su creación en un array. `HandleKeyboard` se encarga de identificar las teclas presionadas por el usuario y asignarles funcionalidad.

### **Settings Menu**

Cumple con las mismas funcionalidades que el menú principal, a excepción de que las funcionalidades de ajustes aún no han sido desarrolladas.

### **In-game Menu**

Aún en desarrollo.

---

## **Pokemon Class**

La clase `Pokemon.cs` se encarga de la creación de los pokemones como objetos, de tal forma que se les pueda asignar nombre, atributos y niveles en su creación. Los valores a asignar para los pokemones ya existentes (`Pikachu` y `Charizard`) fueron sacados de la Wiki oficial de Pokemon, de tal forma que estos valores no deben ser aleatorios en su creación.

---

## **Bag Class**

Las `Bag`s o mochilas son objetos cuya función es almacenar los items aleatorios generados para los jugadores. Cada jugador tiene una mochila, y esta genera items aleatorios de una lista de items en cada partida.

La clase `Bag.cs` Se encarga de la creación de estos objetos. Esta recibe un array de objetos aleatorios como parámetros y se los asigna a un array `Items` dentro de sí misma.

## **Move Class**

Los `Moves` hacen referencia a los movimientos y ataques de los pokemones. Esta clase se encarga de construir los movimientos y guardar tanto sus nombre como sus tipos. El daño de cada ataque es dependiente del daño de ataque, ataque especial y tipo de ataque del pokemon, de tal forma que las estadísticas del pokemon y el tipo de ataque afectan al daño recibido por el pokemon atacado.

## **'TRASH' prefix**

El prefijo `TRASH` en los nombre de algunos archivos `.cs` hace referencia a clases que han sido utilizadas anteriormente y que cumplieron con algún propósito, pero que ya han sido reemplazadas, mejoradas o rehechas, y quedan como archivos residuales en caso de ser necesarios en un futuro cercano.

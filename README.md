# EspiralesFibonacci
El problema de como distribuir N puntos de manera uniforme en una esfera es un problema antiguo muy estudiado que solo puede ser solucionado si se conoce el número N.
Existen muchas maneras de abordar el problema, pero no voy a profundizar al respecto, los siguientes enlaces son útiles para tener mayor documentación:

- https://stackoverflow.com/questions/9600801/evenly-distributing-n-points-on-a-sphere
- http://extremelearning.com.au/evenly-distributing-points-on-a-sphere/
- http://extremelearning.com.au/how-to-evenly-distribute-points-on-a-sphere-more-effectively-than-the-canonical-fibonacci-lattice/
- https://newbedev.com/evenly-distributing-n-points-on-a-sphere

En mi caso, he decidido implementarlo a través de un método conocido como las **espirales de fibonacci**. La fórmula para calcular N puntos alrededor de una esfera de radio 1 es:

+ theta = 2*pi*(i/goldenN)
+ phi = arcos(1-2*(i+0.5)/N)
+ (x,y,z) = (cos(theta)*sin(phi), sin(theta)*sin(phi), cos(phi))

Donde **goldenN** es el número aureo ((1+5<sup>0.5</sup>)/2), **N** el número de puntos que queremos repartir en la esfera de manera uniforme e **i** 
el punto actual que estamos generando de entre 0 y N.

Con la fórmula aclarada, simplemente debemos recorrer los N puntos e ir generando los puntos. En la siguiente imagen podemos ver 300 y 1000 puntos uniformemente generados en una esfera.

300 puntos |  1000 puntos
:-------------------------:|:-------------------------:
![](https://user-images.githubusercontent.com/61519721/142776508-f1d4ba57-aa9b-4224-8683-d692483bdb5a.PNG)  |  ![](https://user-images.githubusercontent.com/61519721/142776507-c418b8ed-fa70-4d54-a9eb-1dcbdac5885d.PNG)

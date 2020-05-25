# 3DShootingGame on Unity

## About
If use these scripts, you can create a 3D Shooting style mini game on Unity.

## Development environment
macOSX  
Unity 5.4.5p5 (but confirmed to work with version 2019.3.13f1)

## Demo video
* **controling**  
<img src=https://user-images.githubusercontent.com/47848514/82777343-d127aa80-9e88-11ea-8b50-ad8f5efbcba3.gif hspace=35 width=50%>

* **shooting**  
<img src=https://user-images.githubusercontent.com/47848514/82777347-d2f16e00-9e88-11ea-9662-cea54d5477b8.gif hspace=35 width=50%>

## Sample resource setting
* **Player**  
![Player](https://user-images.githubusercontent.com/47848514/82777345-d258d780-9e88-11ea-8bbf-6a84ce5f1822.png)
* **Boss**  
![Boss](https://user-images.githubusercontent.com/47848514/82777342-cff67d80-9e88-11ea-8068-54610e27280a.png)

## Note
There are using specify name such as below in some parts of these script.
* **Player** : Game Object you'll control.
* **Boss** : Big white enemy in the video. When this boss is destroyed, game clear.
* **MidBoss** : Small blue enemy around the Boss in the video. The MidBoss is prehub. The Boss receive no damage until destroying all the Mid Boss. In addition, the Mid Bosses will revival in some seconds.
* **GateX** : Empty Object which mark appearing point of MidBoss. When X is a Gate Number. the Gate Number is from 1.
* **RouteX** : Empty Object which mark Boss moving to. When X is a Route Number. the Route Number is from 0.


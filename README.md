# BENVISION
## BEN stands for Binaural Experience Navigator. We enable visually impaired individuals to experience the world around them through a combination of state of the art real time Machine Learning algorithm and Augmented Reality. We give them the ability to see objects through artificial intelligence and then convert those objects into soundscapes. Interestingly, Ben is also the name of the blind American diagnosed with retinal cancer who taught himself echolocation and was able to detect the location of objects by making frequent clicking noises with his tongue.

## How it works?

## Our solution uses a depth sensing camera, enhanced with a real-time machine learning algorithm, to identify objects and convert them into a harmonious soundscape as the user moves through the environment. Every stationary object in the environment is associated with a unique ambient sounds, while haptics indicate whether they are interactive, providing a one-of-a-kind beautiful synesthetic experience. These experience will mimic 4 aspects of vision namely: (1) Look; (2) Focus through use of controller; (3) Observe and (4) Enjoy which includes activation of particles

## View our project at https://heroic-croissant-9334b4.netlify.app/

![Screenshot](screen.png)

### Projects used
* AI - Yolo : https://github.com/wojciechp6/YOLO-UnityBarracuda 
* UnityNativeCamera:  https://github.com/yasirkula/UnityNativeCamera 
* ChatGPT to solve some problems ;) 

## How Application is working on Snapdragon Spaces Lenovo ThinkReality?
Our project utilizes YOLO (AI) for object detection such as aeroplanes, bicycles, birds, boats, bottles, buses, cars, cats, chairs, cows, dining tables, dogs, horses, motorbikes, people, potted plants, sheep, sofas, trains, and TV monitors. It does this every 800 frames using image data from a camera. The volume of sound produced is dependent on the object being detected and is divided into 8 different categories (with plans to expand in the future). The distance from the object is determined by the size of the object recognized by YOLO and in newer versions we will be adding depth recognition as well.

## Builds and videos:
* ![MacDemo](\Builds\Ben Vision_SoundScapes Demo_Unity Build_Mac.zip)
* ![Windows](\Builds\Ben Vision_SoundScapes Demo_Window.zip)
* ![ThinkReality](\Builds\sight.apk)
## Videos
* ![Introduction](\Builds\Introducing_BenVision_v3.mp4)
* ![DemoVideo](\Builds\Ben Vision_SoundScapes Demo_Video.mp4)


### 2020
Toolchain:
* Android Studio 4.0.1
* Android SDK 9.0 (API 28) Rev 6
* Android NDK (Side by side) 21.3.6528147
* CMake 3.4.1
* Unity Hub 2.3.2
* Unity 2020.3.35f1
* Qualcomm Snapdragon Spaces 0.9.0
* AI - Unity Barracuda 1.0.4

## Troubleshooting

If you have trouble building the Unity project, please try the following:
```
Open "Build Settings" and make sure that you have switched to the "Android" platform.

This should allow you to build successfully.
```

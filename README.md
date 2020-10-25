# MotionDecoder
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/xfox111/MotionDecoder)](https://github.com/xfox111/MotionDecoder/releases/latest)
[![GitHub issues](https://img.shields.io/github/issues/xfox111/MotionDecoder)](https://github.com/xfox111/MotionDecoder/issues)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
![GitHub repo size](https://img.shields.io/github/repo-size/xfox111/MotionDecoder?label=Repository%20size)
![Platforms](https://img.shields.io/badge/platforms-win32-lightgrey)

[![Twitter Follow](https://img.shields.io/twitter/follow/xfox111?style=social)](https://twitter.com/xfox111)
[![GitHub followers](https://img.shields.io/github/followers/xfox111?label=Follow%20@xfox111&style=social)](https://github.com/xfox111)

## Overview
This project is used to analyze videos from security cameras and shows short clips from the videos which contain detected motions.
It uses C# programming language, .NET Framework 4.6 and [Accord.NET](http://accord-framework.net) libraries

## Algorithm overview
1. The algorithm reads first frames of every half-second (e.g. if a video has framerate of 30 the algorithm retrieves 1st frame, 15th, 30th, 45th and so on)
2. Images are converted to Grayscale
3. Images' pixels are compared to each other
4. Highlights regions with an area of changed pixels 35x35 or more
5. Creates video segments metadata based on "moving" frames
6. Segments with the distance between is less than 5 seconds are combined
7. Segments with the duration less than 3 seconds are deleted
8. Segments data is recorded to ".data" file with JSON structure

## Screenshots
![](https://github.com/XFox111/MotionDecoder/blob/master/Src/Screenshot1.jpg) 
![](https://github.com/XFox111/MotionDecoder/blob/master/Src/Screenshot2.jpg)

## Dependencies
- **K-Lite Codec Pack** - used for video playback. The program will crash without this codec. Other codecs might do well but I've not checked.
- **DirectX Playback library** - used for playback as well as codec

## Getting Started
1. Install [K-Lite Codec Pack](https://www.codecguide.com/download_kl.htm) (Any edition will do)
2. Launch Visual Studio 2017 or later
3. Go to "View -> Team explorer"
4. In the Team explorer click "Manage connections button" and click "Clone" button
5. Insert Git URL from repository GitHub page and clone repository to your PC
6. Open MotionDecoder solution
7. Go to "Solution Explorer -> MotionDecoder -> References" and check if all dependencies are loaded
8. If DirectX libraries are missing add them through "References -> (double-click) -> Add Reference -> Browse" (Libraries are situated in "{Repository root}/Dependencies")
6. Build and debug solution

## Copyrights
> ©2020 Michael "XFox" Gordeev
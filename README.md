# BlindEyes
_Created for MR Dev Days 2022 - Microsoft Hackathon_

Humans are born with 5 senses: smell, taste, touch, hearing, and sight. However, over many millennia, humans interacting with the environment around them have lost one or more of their senses. One of humans' most informational senses that provides great detail on the space around them is sight. Sight trains our spatial awareness, and helps us remain aware of both our stationary and moving surroundings. The sensory impairment of sight, known as blindness, limits the cognitive abillity to map space and hinders conciousness of surrounding objects.

The history of blindness has not been as well documented as other disabililties. Early glasses can be dated back to the 13th century in Italy, but notable visually impaired figures such as Hellen Keller and Louis Braille only date as far back as the 19th century. Though lacking visual prowess, such people have improved versions of the other four senses. 

So, what if we were to see with another one of our senses to map our surroundings, specifically sound?
BlindEyes is a way for the visually impaired to better see objects in their vicinity through enhanced sound. Currently, BlindEyes only has sound integration, so it is useful for those who are completely blind and cannot use sight to map the space around them. However, visual feeback is a work in progress, and will be integrated in the near future to improve the spatial awareness of those who are not completely blind.

Features:
* Togglable, automatic radar scanning of surrounding space using spatial sound
* Manual radar scanning of surrounding space using spatial sound (WIP)
* Visual feedback for radar scanning a space (WIP)

Future Features:
* Multilayer radar scanning
* Moving object tracing and detection
* Visual feedback for moving objects

Built for **HoloLens 2** using the preview release of **MRTK3**

Steps to Build BlindEyes onto HoloLens:
* Step 1: Download latest release of BlindEyes onto a Windows computer/laptop **and** Visual Studio

_If you want to use the latest build rather than the latest release, then open project in Unity, use a Universal Build Platform with ARM, and then follow remaining steps_

* Step 2: Physically connect your Hololens2 using USB-C port
* Step 3: Extract build (if zipped) and open BlindEyes.sln
* Step 4: Change build type to "Master"
* Step 5: Change architecture to "ARM" 
* Step 6: Change build destination to "Device" 

After Steps 4-6, the top bar of your BlindEyes.sln should look like this:
![image](https://user-images.githubusercontent.com/30392769/174676195-dd321194-96a3-4078-a67c-c94574a318ff.png)

* Step 7: Hit the green play button with no color fill _Start Without Debugging_ (directly right of "Device")
* Step 8: Once the download finishes, go to "All Apps" on your Hololens2 and search for BlindEyes
* Step 9: Enjoy :)

**Sources**

Citations:

Ackland, Peter et al. “World blindness and visual impairment: despite many successes, the problem is growing.” Community eye health vol. 30,100 (2017): 71-73.

Links:

https://www.ncbi.nlm.nih.gov/pmc/articles/PMC5820628/
https://www.britannica.com/topic/history-of-the-blind-1996241
https://allabouteyes.com/see-past-fascinating-history-eyeglasses/#:~:text=The%20first%20wearable%20glasses%20known,or%20perched%20on%20the%20nose.

# SimpleSteamNews
This is a small project I'm creating. The objective is to build a very lightweight tool that works with the Steam web api to bring the user a Steam game news feed curated according to their preferences. The application should allow the user to easily select games they are interested in hearing news about and serve these news feeds in a consolidated, minimalistic format.

<h3>Update 2/28/2017
This project has been discontinued as its functionality has been retooled and rolled into my web application.</h3>



Update 1/13/2017

Returning to this project to see if I can finish building it out. I've remade the repository in order to directly integrate with visual studio. I'll be attempting to implement a UI in the next few days.

Update 11/30/2016

This is just an update implementing a system to find Steam application ids through the parsed list of app names and then pull the news feed from the API by concatenating the appid into the http request. I'm certain none of what I've done here is optimal but with the limited knowledge I have of conventions regarding this sort of framework this was my first attempt. I hope I can show this to someone with more experience so that I can get some feedback about the approach I'm using. A major confusion I'm having is assessing what the most reasonable way to abstract functionality is in a given situation. For example I ended up stripping the retriever class of almost all of its previous specificity in an effort to leave the class in the most broadly useful state possible. Unfortunately this leaves me confused as to what the actual purpose of having the class is when almost all its functionality is described in a single method. What is the purpose of instantiating an object in order to execute a single method. With such a small amount of calculation taking place I'm sure this is not a large problem but nevertheless it seems wasteful to create an object to run a single method. Perhaps this confusion is just a consequence of the fact that everything I'm currently doing is being executed automatically with no user input. Maybe once I implement a user interface the relevance of instantiating objects for these small tasks will be more clear.

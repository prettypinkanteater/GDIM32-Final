# GDIM32-Final
## Check-In
### Group Devlog: Prompt B

We used sphere-casting for the feature of identifying when the player is looking at and near interactable objects
to use them. This includes picking up as well as putting down ingredients, picking up utensils, and generally interacting 
with appliances required for quest completion. We wanted the player to only be able to interact with those items within a 
specified distance from themselves so that it was clear which item the player was specifically being prompted to interact 
with. Otherwise, all items within view regardless of distance would simultaneously prompt the player and there would be a
lack of gameplay clarity. 

Sphere-casting was implemented because it returns information about the object it hit via a RaycastHit variable within the 
specified radius/area surrounding an origin as defined in its parameters. It also has a direcion and max distance of projection.
In this way, the radius of the sphere-cast can identify if the distance between the player's view, as it is directionally in front of them,
and an interactable object is the required distance for the player to be prompted to interact. 

This is inside an if statement in the player class/script and we utilized the returned information by getting from the 
hit object's collider component to the overarching gameObject in order to store its tag, which identifies the interactable
item's specific type, in the colliderTag variable. Following this and also inside the if statement is a switch statement with
each case condition being the tag of the object that the player is looking at. Since the conditions focus on interactable objects
only, counters or other scene elements will not trigger the prompt. Other additional case conditions include the booleans that manage
quest progress, like whether or not an ingredient has been placed in order to pick up a utensil to operate on it. If the conditions
for a case are met, then the method showing the interaction prompt UI is called. 

work w/ group 
(mention promptOn bool?)
This is relevant to our feature becaues With the if statement, we can 
use an else statement to hide the prompt if the sphere-cast doesn't detect anything.

### Team Member: Audrey Hu

I wrote the Item parent abstract class containing the PickUp() and PutDown() methods. I also primarily wrote the Utensil and 
Ingredient child classes that contain polymorphic unique additions to the parent class’s PickUp() and PutDown() methods. For 
example, the potato gameObject with the ingredient script attached would have its position parented to the cutting board when 
put down while the knife gameObject with the utensil script attached would not do this. I also created the Locator class with 
the player reference before the other controller script references(s) were added. In terms of things built in Unity, I set up 
the knife’s gameObject, animation controller, and the cutting animation clip. I also implemented audio (audio listeners and 
sources) for the background music required for this stage and to prepare for the next stage involving sound effects.

The Proposal has been significantly helpful because of our level of detail. The break-down has not been helpful as i
t is literally a visual reflection of what our proposal describes and I do not prefer that format. The Proposal on the other 
hand, with its sequential and distinctly separated order, is more intuitive and logically organized as a blueprint for building 
(i.e. item -> item actions). My team then used Trello to divide and assign the tasks that would align with this blueprint. The 
clarity of our Proposal definitely helped us identify and simplify the tasks easily. Afterwards, and because I became familiar 
with our game’s mechanics and content, I did not need to look at the Proposal frequently. The only time I did reference it 
actively was while trying to download the exact sound effects planned for early on in the build process.


### Team Member: Brenden Johnston
Put your individual check-in Devlog here.


### Team Member: Nolan Burns
Put your individual check-in Devlog here.


## Final Submission
### Group Devlog
Put your group Devlog here.


### Team Member Audrey Hu
Put your individual final Devlog here.
### Team Member Brenden Johnston
Put your individual final Devlog here.
### Team Member Nolan Burns
Put your individual final Devlog here.

## Open-Source Assets
Cite any open-source assets here. Put them in a LIST, and use correctly formatted LINKS.

- [Sizzle_Frying Pan_Fienup_001.wav](https://gamesounds.xyz/?search=sizzle)

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

### Team Member Audrey Hu
Put your individual check-in Devlog here.
### Team Member Brenden Johnston
Put your individual check-in Devlog here.
### Team Member Nolan Burns
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

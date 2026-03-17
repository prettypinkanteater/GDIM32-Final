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
specified radius/area surrounding an origin as defined in its parameters. It also has a direction and max distance of projection.
In this way, the radius of the sphere-cast can identify if the distance between the player's view, as it is directionally in front of them,
and an interactable object is the required distance for the player to be prompted to interact. 

This is inside an if statement in the player class/script and we utilized the returned information by getting from the 
hit object's collider component to the overarching gameObject in order to store its tag, which identifies the interactable
item's specific type, in the colliderTag variable. Following this and also inside the if statement is a switch statement with
each case condition being the tag of the object that the player is looking at. Since the conditions focus on interactable objects
only, counters or other scene elements will not trigger the prompt. Other additional case conditions include the booleans that manage
quest progress, like whether or not an ingredient has been placed in order to pick up a utensil to operate on it. If the conditions
for a case are met, then the method showing the interaction prompt UI is called. 


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


### Team Member: Brendan Johnston

I created the UI script as well as set up the canvas with the “E to interact text”. Along with this I set up the player class, 
player movement, and the first person camera. Using this and a spherecast we all had a hand in creating, I set up the code for a 
showprompt() and hideprompt() method in the UI script to use when the player is looking at an object. I also created the gameController 
class and object and identified the required booleans to be able to only pick up certain items based on quest progress. Then I 
created the framework for using those booleans within the switch statement in the spherecast if statement to only showPrompt() 
on ingredients, utensils, or appliances based on what has already been done to ensure the correct order in the quest. I created 
the system for the object you are holding to be rendered over everything else using a second camera on the player so that those 
items don’t clip through objects in the space. 

Our proposal was highly detailed which made it very easy to understand what our concept was and what features we wanted in the project. 
However, the breakdown has not been very useful. I have never particularly liked or used the breakdowns we’ve made in the past and this 
time is no different. The proposal was laid out brilliantly in order for us to create a concrete idea then move on to other systems 
like Trello once everything was set in stone. 



### Team Member: Nolan Burns
I sourced and implemented most of the assets present in the scene, including the restaurant, pufferfish manager, and the various appliances. 
I was responsible for decorating it and added the various sources of lighting and the skybox. This meant I also created and tuned most of the colliders. 
I created the manager GameObject and his Manager class, utilizing the Locator singleton to reference the player’s location. 
I also implemented his animations, though most of the animation work was eventually scrapped in favor of a more effective method. 
I also created the goals UI element and updated it through the Utensil and Ingredient classes using the Locator singleton. 
I used the architecture concept of the Model-View-Controller pattern with the ItemUsed event within the Utensil child class to implement cutting the manager. 

The proposal has been relatively useful, especially for keeping track of what we need to accomplish and how to tackle certain aspects. 
I found it sufficiently detailed to where we have yet to address any significant additional details. 
The breakdown was moderately helpful to make because it forced us to think of all the GameObjects we would be creating and what they would have, but it lacks the detail and structure to assist with scripting. 
Our architecture plans seemed great when we first made them, but it has been hard to adhere to the Model-View-Controller pattern with events and decoupling. 
As we progress onto more challenging tasks we may have to revisit how we use the architecture or rework some of our previously written code to align with it better. 
We have used Trello to keep track of our progress and remind ourselves of the tasks we need to accomplish. We also used a Google document with a list of potential and used assets to make it easier to locate them later on. 



## Final Submission
### Group Devlog
The Model-View-Controller design pattern is mostly evident with how the 
DialogueController script, the controller/logic, manages the advancement and 
branching of the dialogue data/model that is separate but referenced for use. The 
data is stored in the DialogueNode-based ScriptableObjects, each 
containing specific dialogue strings. The controller then imparts this, like which 
line to display, to the UI gameobjects/components that make up the game view 
using the DialogueUI class. The UI is also separate and accessed via references. 
The UI class uses events to update the objectives text, which allows it to be decoupled 
and work well when other methods need to be tied to a specific action.

This is useful/helpful because otherwise there would be immense coupling and a
massive reference list that would consequently make it difficult to edit one part of 
the system, like data, without having to accommodate for changing or working 
around other parts, like programmed logic. If we wanted to add more lines to 
existing dialogue, we would not need to edit the DialogueUI script to ensure that 
the Advance() method continued to the new last line.

The Locator singleton class helped various systems easily access 
the overarching quest progress via the GameController script and subscribe to Player 
interaction events without needing direct references. In this way, the player picking up/putting down or using items makes 
it so that the entire game, made up of the various systems, can easily cohesively react. 
For example, when the player puts down an item, the Player class invokes the PutDown event, 
which the AudioController class and Ingredient class are subscribed to using the Locator. 
The result is that the right sound effect is played and the ingredient being put down game 
logic runs. The Ingredient class can subsequently and likewise access the Locator class 
reference to the GameController script and change the value of the placedIngredient bool 
to true and hasIngredient to false. This simplification of access decouples scripts while 
also enabling interaction between them.

Inheritance further helped us decouple code by not forcing us to repeatedly implement and
rewrite shared methods for shared item interaction capability regardless of item type 
because the child classes, Utensil, Ingredient, Appliance, and WhallyPlacement, have 
definitions implemented by the Item class parent they inherited from. Namely, the Item 
class has PickUp() and PutDown() base methods that are utilized by both the ingredients 
and utensils. Polymorphism enhanced this by allowing us to override the base parent 
defined methods, like appliances that were not to be picked up, and add/edit methods, 
like signaling the end of a quest based on finished item use, in child cases that were unique. 


### Team Member Audrey Hu
I wrote the AudioController script/class containing the methods relevant to playing specific sound effects. 
I set up the cookingTimer and cookingTime variables as well as the base timer functionality in the Appliance class.
I worked a little bit alone in the Ingredient class to address the PutDown() method but frequently pair programmed 
(even triple programmed 😛) with Brendan for quest completion logic in basically all the Item classes, the 
GameController class, and the player class. You will see my atrocious commentary highlighted by the name of one of 
his commits.

I created/fine-tuned the spatula flipping and proper positioning animation clips as well as updated the Utensils 
animation controller to accommodate for it. I also fixed the knife positioning and chopping clips.
I fixed and implemented waiting for the knife chopping clip to finish with animation events and by shifting player 
event subscriptions around in the ingredient and utensil classes. I created Bouffi and Timmy’s nametags in Unity as well.

### Team Member Brenden Johnston
- Managing camera layering when adding new systems
- Controlled the player sensitivity
- If statements into the ingredient class to dynamically change its layer / interactivity via the gamecontroller quest booleans
- Utensil and ingredient code (and setting up their gameobjects) for switching the models from knife to spatula and the two foods from the raw, 
  cooked or cut, and finished states
- Created an insults script and textbox for Bouffi so he cycles through random insults from a list displayed in worldspace every 10 seconds
- Created the functionality to pick up the burger onto the spatula, placing it onto Timmy’s tray, having it turn into a completed burger, 
  picking up the tray, and placing it onto the counter for Whally
	- Created the method and event from gamecontroller to be invoked when the burger gets completed with a method subscribed to it from the ingredient 
      class which changes the model to a burger
	- Created an empty gameobject to parent to on the spatula and on the counter for perfect placement
	- Created a copy of the completed food tray game object to be picked up by the player as if it was an ingredient
	- Created a new script for the tray, inherited from Item abstract class, and placed it onto the new tray object

### Team Member Nolan Burns
I implemented the dialogue system, including the ScriptableObjects for the responses and the related scripts, namely the UI, DialogueUI, and DialogueController classes. 
I tied certain quest booleans into the dialogue system to ensure you had to talk to the NPC for the quest to update.
I also helped with bugfixing to make other interactions only work when the conditions were correct.
I used events and our Locator singleton to update the Objectives text when certain parts of the quests are completed. 
I implemented the Timmy NPC and his animation. I created the fridge animations along with the customer and his animations and the scripts that control them. 

## Open-Source Assets

### Audio
- [Sizzle Frying Pan](https://gamesounds.xyz/?search=sizzle) - fry cooking sizzle sound effect
- [Punch Smack Lettuce](https://gamesounds.xyz/?search=smack) - item assembly/use sound effect
- [Children saying Yay - Praise and Worship Jesus](https://pixabay.com/sound-effects/people-children-saying-yay-praise-and-worship-jesus-299607/) - yay sound effect
- [Angelic Choir](https://pixabay.com/sound-effects/musical-angel-choir-463220/)
- [Door Slamming](https://pixabay.com/sound-effects/film-special-effects-door-slam-478362/)
- [Knife Cut Veggies Foley 4](https://pixabay.com/sound-effects/household-knife-cut-veggies-foley-4-211705/) - knife cutting sound effect
- [Underwater Ambience](https://pixabay.com/sound-effects/nature-underwater-ambiencewav-14428/) - underwater ambience background music
- [Spring in My Step Background Music](https://pixabay.com/music/happy-childrens-tunes-spring-in-my-step-copyright-free-music-for-youtube-320726/) - spring in my step background music

### Models
- [Low Poly Stylized Knife Pack](https://assetstore.unity.com/packages/3d/props/weapons/low-poly-stylized-knife-pack-299272) - knife model
- [Cash Register](https://sketchfab.com/3d-models/cash-register-87562962d47e48b28cc1b874fa46a47f) - cash register model
- [USA Diner in 3 Times (new, old, destructed)](https://sketchfab.com/3d-models/usa-diner-in-3-times-new-old-destructed-1872c78a7eab4efd9b209a54c83754b3) - diner model
- [Pandazole - Kitchen Food low poly pack](https://assetstore.unity.com/packages/3d/props/food/pandazole-kitchen-food-low-poly-pack-204525) - low poly food and appliance models
- [Fugu](https://sketchfab.com/3d-models/fugu-3a60acfbd68243c8a9afadc179afc92b) - pufferfish model
- [Casual Vegetable Pack](https://assetstore.unity.com/packages/3d/props/food/casual-vegetable-pack-created-with-fastmesh-asset-293783) - low poly vegetable and fruit models
- [Low Poly Food Pack](https://opengameart.org/content/low-poly-food-pack) - burger model
- [Toony Kitchen & Ingredients Model](https://assetstore.unity.com/packages/3d/props/toony-kitchen-ingredients-model-free-301805) - bun model
- [Diner Lamp](https://sketchfab.com/3d-models/diner-lamp-9f0d6acab78e4a84904e4f8ba573118e) - hanging lamp model
- [Ceiling Light Round](https://sketchfab.com/3d-models/ceiling-light-round-5508e18e61e84346b8d51ed73e0f5411) - ceiling light model
- [Crawfish](https://poly.pizza/m/ct4Z0kUIHdT) - Timmy/crawfish model
- [Hamstercage](https://assetstore.unity.com/packages/3d/props/hamstercage-110028) - Timmy cage
- [Cartoon Whale low poly](https://assetstore.unity.com/packages/3d/characters/animals/fish/cartoon-whale-low-poly-197919) - Whale customer model

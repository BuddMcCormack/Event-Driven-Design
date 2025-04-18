# AI System Implementation DOD ( Design Outline Document )

### AI Architecture :

My original design intention was to make a 3 states patrolling guard which attacks the player if the player is spotted along a patrol route, and would chase the player for a distance or until hidden.   However I decided to go with a more direct approach, making it so the AI would have an attack radius instead.   The AI has three states and 2 detection radius to consider, a chase radius and an attack radius.

### AI Behaviors :

 When the player is outside both radius, the state is set to patrol and the guard will patrol and walk to a random navigational node within 5 units of itself.

When the player reaches the inside of the chase radius the guard begins to pursue the player attempting to corner them or cut them off.

Lastly, when the player is inside of the attack radius the guard begins firing at the player attempting to kill them.


### AI Interaction Design :

The interaction design between the player and the AI was that the AI would dynamically affect the routes and strategies the player decided to take in the level.  The AI has the ability to do things like move patrol positions and can be used to press buttons, they can also be pushed by boxes.   This leades to a dynamic interaction between the player, the present event systems, and the AI enemy.

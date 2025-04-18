# AI System Implementation

### How AI behaviors influence player strategy and decision-making. 

The AI states that I've designed influence player strategy and decision-making by directly challenging the player as they move through the level, the AI influences strategy because it is an obstacle for the player to overcome and therefore influences their decision-making throughout the level.   This includes instances like pushing a box to block incoming shots from an AI, or taking different routes to avoid the AI patrols.

### How player actions dynamically alter AI states and responses.

The players actions dynamically alter the AI states and responses through a detection radius, the AI begins in a patrolling state and once the player is in radius they begin a chase state which culminates in the third state which is attacking.   Each state requires the player to be at a determined distance from the AI.  The dynamics come from the ability for the AI chase state to change the position of the enemy patrol, this plus the randomization of the AI patrol route means that the patrol area is always dynamically changing as the player navigates through the level.

### Challenges faced during implementation and their solutions.  

Surprisingly to me, once I broke down the AI implementation in the design document it was relatively easy to design and implement.  There was a few hitches in the way the AI would detect the player which were solved by having and then adjusting a detection radius.  One of the biggest challenges I faced during this assignment was actually getting the AI to attack the player and deal damage, the way I solved this was slowly tweaking small things until I had an end product that worked.  The original intention was to have the enemies launch rocks at the character over a set interval, where the rocks would fly upward and towards the player at a fixed interval.  However this proved to be very difficult, and still I wasn't able to get the AttackInterval working.   I worked around the issue making it so the player would have a lot of health relative to each projectile launched and by making the lifespan of the projectile shorter so that it would instead seem to shoot like a flamethrower or laser.

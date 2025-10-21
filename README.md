#Group Summary
With the project required an implementation for each member in the group, I thought it would be easier to work alone as I was struggling to come up with a project concept that used each design pattern once.

# Gameplay Summary
The game I  made for this project was a simple crafting game that was very loosley inspired by my enjoyment of factory type games. There is a long list of crafting recipes that you have to go through, with each recipe is a button either labeled "Build" or "Sell". Pressing "Build" will make more of that item if you have one of all the necisary parts, pressing "Sell" will sell 1 of the item giving you more gold, as long as you have one in your inventory.

<img width="827" height="913" alt="game engine year end diagram drawio" src="https://github.com/user-attachments/assets/f55d3f5f-ba7b-459d-836e-a8b3261485bb" />


# Singleton Implementation
<img width="656" height="622" alt="Screenshot 2025-10-20 003920" src="https://github.com/user-attachments/assets/0970d952-c9e3-4fe3-9dd8-3e3dbff5d51d" />

The singleton is essentially the inventory for the player, holding all of the current items that the player has, as well as their current gold value. It also holds all the functions for accessing the inventory so the code wouldn't need to be replicated for every script that has to access it. This is usefull as alot of the scripts refrence the inventory, so adding it to a singleton gives all scripts easier access to it and it's variables.

# Command / Factory Implementation
<img width="495" height="581" alt="Screenshot 2025-10-20 004139" src="https://github.com/user-attachments/assets/a7dd3845-d36b-46bc-8ed4-871794170c60" />

Factory and Command were implemented at the same time as it made accessing the factory much easier. Essentially, each child of the Recipe class holds all the values that it requies for the recipe and it's outputs, with it being the Factory part of the script. Then, whenever the player presses the build button, it has to access it and run the "TryToMake()" funtion that acts as the "Execute()" funtion in the lecture examples.

# DLL Implementation
<img width="318" height="241" alt="Screenshot 2025-10-21 183339" src="https://github.com/user-attachments/assets/acc55675-c97e-401b-8188-bd8d7da94d3f" />

The way I implemented the DLL in my project was by making it calculate the cost of the outputs from the cost of the inputs. The reason I did cost calculation within the DLL is because of the type of project I am makimg is something with a factory like production. With how many types of games have costs and resource refinement, putting all of it in an easy to port over file is a great way to keep a similar system for other games for easier testing. It works by taking an input of costs, which can be any specification but was coded within the project to be the costs of the building inputs. If there is no input value, it returns a float of 1, if only 1 input is there, it returns the cost of the input multiplied by 1.25. If there is 2 or more inputs, it takes the highest valued input, and half the second highest value, all multiplied by 1.25.

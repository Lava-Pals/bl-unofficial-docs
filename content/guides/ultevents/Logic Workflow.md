This is a short and brief explanation of how your UltEvent logic is supposed to be setup for easier use/read.

- `Logic` (Has all of your logic under it)
	 - `Logic Name` (The name of the specific logic. e.g ParentToRig)
		 - `Funcs ↓`
			 -  `Function 1` (Contains an UltEvent Holder that you can invoke, to do something. e.g parent)
		 -  `Events ↓`
			 -  `Event 1` (Contains an UltEvent Holder that gets invoked when something happens. e.g OnParent)
		-  `Internal` (Internal logic that you don't need to access after it's done)
			- Logic Logic Logic
		- `Var` (Contains variables you need to store. e.g position)
			- Position (The transform position could be 0,5,0)

##### See [[General Tricks and Tips]] for more info about a better workflow
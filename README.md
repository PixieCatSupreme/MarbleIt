# MarbleIt
A small terminal program that takes a Trello board json export and saves it into a csv file that Marbles on Stream can read.

## Setup
Download the program and unzip it somewhere.

Go to the Trello board to want to convert and click the menu button in the top right (the three dots).
Click on "Print, export and share" and then click on "Export as JSON".

![image](https://github.com/user-attachments/assets/18ee1b38-17d9-45c6-bed4-63a5e0d78dd8)

Put the json file in the "Input" folder next to the "MarbleIt" executable (if this folder does not exist, you have to make it).

Write the lists you want to export in the "TrelloListNames.txt" file, one name per line.

Run the program and it should put a csv file in the "Output" folder.

Run Marbles on Stream.

Select the gamemode you want to play (Race recommended).

Click the gearwheel in the top right (this will open a settings menu at the bottom)

Click on the blue "Add Names" button.

![image](https://github.com/user-attachments/assets/8c2278c8-9c27-4b8d-9577-fd0d564eeddd)

If there are names in the list, click on "Clear".

Click on "Open" and open the csv file you just generated (take note of the name count at the top).

![image](https://github.com/user-attachments/assets/be9fd4c5-c9bd-475b-8a8d-0e3e46e81a4f)

Click on "Finish".

Select a track, change "Race Type" to "Bots" and set the "Max Racers" to the name count.

Press "Play!" and see ypur Trello cards race to the finish! :)

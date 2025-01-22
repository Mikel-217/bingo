A bingo project, built with .NET Blazor. This bingo works with words and can be filled with your own words.

Features that will be implemented soon:

- Live Chat
- Edit existing words in your file

<h1></h1>

How to set up your own bingo:
1. Clone the repository.
2. Go to the "Data" folder in wwwroot.
3. Delete the existing words.
4. Add your own words inside the "bingoWords":[].
5. Save the file.
6. Change the admin password: navigate to Pages --> Adminpage.razor --> code line 79/80.
7. Save the file.
8. Open Home.razor.
9. Change the title in line 7 to your bingo name.
10. Open the terminal.
11. Navigate to the folder where the project is located.
12. Type dotnet publish.
13. Find the release version in the folder bin --> release --> publish.
14. Upload it to your webserver.

<h1></h1>

How to play:
- Fill it with words a person says often.
- If the person says the word, click it.
- 5 in a row (only diagonal or from top to bottom) means you win!

<h1></h1>

Have fun!

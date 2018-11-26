# GhostGame
In the game of Ghost, two players take turns building up an English word from left to right. Each
player adds one letter per turn. The goal is to not complete the spelling of a word: if you add a
letter that completes a word (of 4+ letters), or if you add a letter that produces a string that cannot
be extended into a word, you lose. Basically, each player should try to extend the game as much as
possible so the rival loses if one of those conditions are met.

Write a program that allows a user to play Ghost against the computer.

The computer should play optimally given the attached dictionary. The human should start to play
first. If the computer thinks it will win, it should play randomly among all its winning movements; if
the computer thinks it will lose, it should play so as to extend the game as long as possible (choosing
randomly among choices that force the maximal game length).
Your program should be divided into server and client side code. It should allow a human to play
against the optimal computer player from inside a web browser through a basic GUI. The server side
code should be written as an ASP.NET web application and the client side code should obtain
information from the server asynchronously. For the client side code, you can use whatever
JavaScript library you prefer or vanilla JavaScript.

Please submit your source code, configuration instructions, and any comments you consider
necessary on your solution approach.

While the core functionality of your solution is important it is also important to exhibit good
structure. Criteria will include readability, maintainability, testing, appropriate data structures, etc.
https://en.wikipedia.org/wiki/Ghost_(game)

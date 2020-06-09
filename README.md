![.NET Core](https://github.com/leonheld/Agnokasten/workflows/.NET%20Core/badge.svg)

# Agnokasten
Agnokasten tries to be an agnostic but LaTeX-based Zettelkasten type system for thought organization and note-taking, addressing the problem with common Zettelkasten clients that do not properly support complex math equations, making them unsuitable for scientific note-taking.

Basically Agnokasten generates and tracks LaTeX templates and documents to be used as a Zettelkasten.
You don't have run in a certain app or text-editor, anywhere works as it is only CLI. Its written on .NET Core 3.1 in C#, making it multi-plataform.

It has two main processes of organizing itself: Tags and Groups. Tags are unique identifiers of a file, consisting of the current datetime and a short name. Groups are abstract sets where many tags can belong to, like "Calculus", "Eletromagnetism", "Linear Algebra" or any specific topic. Tags can be cross-reference from inside other documents, and tags are organized via groups.

# todo:

1. Better CLI argument parsing
2. ~~Add more support for a environment-agnostic filesystem.~~
3. Add support for file tracking and text-based network visualization.
4. Better group integration.
5. ~~Add a json file to hold all metadata information about zetts already created.~~
6. ~~Make the IO system a little bit more generic~~ somewhat, still needs a little bit of work. Maybe cook some nice interface or something.

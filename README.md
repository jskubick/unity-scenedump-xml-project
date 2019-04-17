Unity-Scenedump-Xml is a configurable Unity Editor extension that generates an XML representation of a Scene 
hierarchy. 
(Example output: 
[Terse](http://github.com/jskubick/unity-scenedump-xml-project/blob/master/samples/scene-terse.xml)
or
[Verbose](http://github.com/jskubick/unity-scenedump-xml-project/blob/master/samples/scene-verbose.xml)
)

# IMPORTANT

This repo has a submodule. 
If you don't know what this means, make sure you actually **read** the [Installation section](#Installation),
or it's probably *not* going to work.

# Installation

**IMPORTANT!** This project uses a submodule. If you don't know what that means, read the directions and follow them carefully (esp. the **--recursive** flag).

How to clone this example project **and** the files needed for the Editor extension in one shot:

`git clone --recursive https://github.com/jskubick/unity-scenedump-xml-project.git`

Note the **--recursive** flag. It's important. If you omit it, you'll likely end up with an empty directory named Assets/Editor/unity-scenedump-xml.

If you screw up, see the [unity-scenedump-xml submodule's README.md file](https://github.com/jskubick/unity-scenedump-xml.git#Troubleshooting). 

If you want to use the extension with your own project, instructions are in the [unity-scenedump-xml submodule's README.md file](https://github.com/jskubick/unity-scenedump-xml.git#Installation)

Ditto, for [the rest of this project's documentation](https://github.com/jskubick/unity-scenedump-xml.git)


### Weird error while atempting to recursively clone the repo under Windows?

1. If you got the error while running git from a "normal" cmd.exe or Powershell window, try running it from a "Git Bash" prompt instead.
   * The canonical reference implementation of Git uses Bash scripts to implement some functionality, including submodules. The fact that Git can run *at all* under cmd.exe or Powershell is a minor miracle in itself... however, it's known to be somewhat brittle.
2. Check your PATH environment variable, and make sure it hasn't been insidiously corrupted or truncated.
   * The exact limit depends upon multiple factors, but generally speaking, if the value of PATH is longer than ~1,500 characters, you might be in trouble. If it's longer than ~1,900 characters, you're probably in trouble. If it's longer than 2,048 characters... you aren't just in trouble, it's probably been insidiously truncated as well. Possibly for months.
   * If you need to shorten it,
     * create 3 symlinks (c:\p, c:\p86, and c:\s) pointing to "C:\Program Files", "C:\Program Files (x86)", and "C:\Windows\System32" (using `mklink -d`), and replace the paths in PATH for those three directories with c:\p, c:\p86, and c:\s respectively. 
      * create a directory c:\p, and inside of it create similar symlinks for the longest paths in your PATH variable. 
      * Note: creating NEW environment variables (like "PF" = "C:\Program Files"), then embedding %PF% within your PATH variable, **won't** solve the problem. The character limit applies to the total EXPANDED length of the string. You'll STILL get weird "path not found" errors, except that when you look at PATH's value, it'll appear to be just fine. You *have* to use symlinks (or NTFS junctions, but those are dangerous, because you can EASILY delete what you THINK is just a folder full of duplicates & have it delete the REAL files before you even realize what happened).
3. If all else fails, try deleting every copy of Git that shows up in the control panel applet formerly known as "Add/Remove Programs", reinstall Git, and make sure the newly-installed version's path comes before any other in your PATH variable.
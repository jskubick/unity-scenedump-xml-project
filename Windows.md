# Warning for Windows users:

If "git clone" normally works for you, but "git clone --recursive" dies with weird error messages complaining about paths or permissions, it's probably because your current Git installation *is* at least slightly broken.

The very condensed version: 

* Windows is a second-class citizen of the Git universe. The canonical version of Git can't be compiled directly for Windows... it basically has to carry around its own private copy of Bash and Linux (via MinGW or Cygwin) to run at all, and it's known to "have issues" if you try running it directly from cmd.exe or Powershell.
* There ARE Windows-native implementations of Git... but they're by necessity written from the ground up, and few/none of them rigorously implement every single feature that's found in the canonical version.
* Windows builds of the canonical version of Git depend upon Windows' environment variables being correct.
* The way Windows handles environment variables is a hot mess.
* SDK installers compound the problem, and can easily leave variables like PATH mangled beyond recognition long before you even realize it's a problem.

Go ahead... look at your PATH variable right now if you're feeling brave. If it's been more than a few months since the last time you reinstalled Windows & you have more than a few SDKs installed, your PATH variable in particular is probably truncated in the middle of something ALREADY.

Before you do anything else, create the directory `c:\p`

Now, create two symlinks:

    mklink -d c:\p\pf "c:\program files"
    mklink -d c:\p\pf86 "c:\program files (x86)"

... and update what's left of your PATH to replace every instance of "c:\Program Files" and "c:\Program Files(x86)" with "c:\p\pf" and "c:\p\pf86"

OK, that should get you a LITTLE bit of breathing room. NOW, look for all of your commandline apps that want to live in their own directory & have it added to your path... say... c:\bin\apache-maven-3.3.9\bin\:

    mklink -d c:\p\mvn "c:\bin\apache-maven-3.3.9\bin"

... and replace that huge path with "c:\p\mvn;"

While you're at it, you probably have a few glaring items that have OUTRAGEOUSLY long paths. SQL Server Express comes to mind as a particularly egregious offender:

    mklink -d c:\p\msql130 "c:\program files\microsoft sql server\130\tools\binn"

... and replace it with "c:\p\msql130" in PATH. 

Try to get your PATH down to 600-800 characters, and repeat this process in the future as newly-installed SDKs and other things cause it to continue growing. 

## Note:

You can NOT solve this program by defining an environment variable like "PF" equal to "c:\Program Files" and replacing "c:\Program Files" with "%PF%". It HAS to be a symlink. Why? Using a %PF% environment variable just makes the problem even MORE insidious. Your paths will look nice & short when you view them from the environment variable editor window, but their FULLY EXPANDED length is the one that really COUNTS. c:\p\pf counts as 7 characters. %PF% *looks* like 4 characters, but expands out and COUNTS as 16 characters. If you try to solve the problem by embedding environment variables within environment variables, you'll just set yourself up for weird error messages suggesting that something isn't in your path... then find them sitting there in plain sight when you print the environment variable's value.

If you're really hurting for space, you can move the symlinks for c:\program files, c:\program files (x86), and c:\windows\system32 directly to the c: drive's root directory, and maybe even give them single-letter symlinks (say, "\f", "\q", and "\s", respectively), shaving them down even further.

Don't try to dispense with the drive letter, unless you want to set yourself up for another round of insidious bugs. The two extra characters it takes to add "c:" to "c:\f" might save your HOURS of troubleshooting 17 months from now.

### anyway, continuing...

Now... uninstall every copy of Git that's listed in Control Panel's add/remove programs, download a fresh copy of Git, and install it. Reboot, just to be safe (this is, after all Windows... probably 80% of the things that cause the computer to be dysfunctional for no apparent reason go away after a reboot).

You can now try to repeat the function that involved submodules from cmd.exe or Powershell. If it still craps out, try doing it within "Git Bash".

## Are you serious?!? All this work just to use your tool?!?

It's up to you, but the fact is, if you're having problems checking out my project with a submodule, your Windows environment (and Git in particular) has probably been a ticking time bomb of dysfunctionality for quite a while ANYWAY. Sure, you can walk away from the problem right now... and if you're really unlucky, the next time Git craps out will be 6-9 months from now, and you'll have completely forgotten everything you just read here... or you'll remember, and be unable to find it again. Unless you're urgently pressed for time, do yourself a favor & fix your broken Git environment NOW. At the very least, fix your PATH problem, because *that's* just going to keep festering and getting worse until you fix it.

  In case you're wondering... yes, I had this exact problem, and learning what it was & how to fix it incinerated several hours of my life.
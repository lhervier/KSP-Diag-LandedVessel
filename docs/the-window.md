# The window

Part of [KSP Diag - Landed Vessel](../README.md): the table the mod shows in flight, column by column.

In flight, a window shows a table with one line per reading, in millimetres. The **bottom line is the
reading in progress**: its numbers move as you watch, it carries `--` where the others carry a record
number, and the *Record* button at the end of it freezes it into the table. The table survives scene
changes, so the lines pile up as you reload. `Alt+F6` hides the window, and shows it again.

![Mod's Window](../imgs/window.png)

**The numbers are about the craft you are flying, or about your target when you have set one on
another craft.** The line above the table says which, by name — `Craft you are flying: …` or
`Target: …` — so that a reading is never about a craft you did not mean. Targeting anything that is
not a craft, a planet or a docking port, changes nothing: the window stays on the craft you are
flying.

That is what lets you measure a craft you are not in. Park one, target it, and drive away: the table
keeps following it. Past 2250 m the game unloads it and there is nothing left to read, which the line
says in as many words — `Target: … -- too far away to read` — and every column falls back to `--`
until you are close enough again.

| column | meaning |
|---|---|
| **On rails** | the last height the game held the craft at while it was running it on rails, before physics started on it — at the opening of a scene, the position the save gives back; for a craft you come back to, the position it is held at until you are within 200 m of it |
| **Settled** | the distance right now, running live until you press the button — so, once the craft has come to rest |
| **Moved** | **Settled** minus **On rails** — how far the craft ended up from the position it was given, this loading. Negative means it went down |

**Moved** is the figure to look at, and it should be zero. The craft was at rest on the ground when
the game took it in hand; handed back at that very height, it has no reason to move at all.

Its sign says which way the craft went — and how much the figure is worth.

**Negative** — the craft came back above the surface it ends up resting on, and dropped onto it. That
is a clean measurement: the figure is the gap it fell through.

**Positive** — the craft came back below that surface, so it started off inside it and the physics
pushed it back out. Still a craft that did not stay where it was put, but the figure itself is
spoiled: it measures how hard it was shoved, not how deep it started.

Two things **Moved** does not tell you.

**A craft the game moved itself reads like one that settled.** At the opening of a scene, the game
sometimes puts a landed craft back onto the ground before its physics starts: stock KSP does it for a
craft made of a single part and for a craft in the *prelaunch* situation, and some mods, such as
[Real Solar System](https://github.com/KSP-RO/RealSolarSystem), do it for every landed craft. When the
craft comes back more than 10 cm off the ground, inside it or above it, it is moved onto it in one
block, and **Moved** then shows that move, not a craft coming to rest. The window cannot tell the two
apart; `KSP.log` can: every such move leaves a line `ground contact! - error. Moving Vessel up X.XXXm`
(or `down`) naming the craft, right before `Unpacking`. That is why
[Taking a reading](../README.md#taking-a-reading) keeps to loadings without that line, and why, where
it cannot be avoided, the lines it moved are to be marked as such.

**A jump or a tip-over does not show in the table.** There is one height per loading, and whether the
craft jumped to get there is something you see on screen, not in the numbers: a jump ends at a height
like any other. A craft that tipped over is worse: its root part now lies on its side, and **Moved**
reads the height of a craft lying down, not one that settled. Note what you saw next to each line.

Watch the live line as the craft settles and you see the demonstration play out: while the craft is
still on rails the two distances are equal and **Moved** reads `0.000`, and it is the first step of
physics that breaks the zero.

Every frozen line carries a *Delete* button, so a line recorded too early — before the craft had
finished settling — costs one click to throw away. *Clear table* throws away the lot. The table lives
in memory only, and empties itself when KSP is closed.


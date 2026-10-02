# The protocol: the runway and the grass beside it

Part of [KSP Diag - Landed Vessel](../README.md): how to take the reading on a craft parked on the
runway, where [the loading protocol](the-protocol-loading.md) tells you not to go. The columns it fills
are in [The window](the-window.md), and what it reads is in
[The measurements: the runway and the grass beside it](the-measurements-runway.md).

A craft on the runway rests on the runway deck, a structure the game puts in place its own way, not on
the terrain. One craft there would only say that it comes back at a different height at every loading.
So this protocol parks **two identical craft**, one on the runway and one on the grass beside it, and
reads both at every loading. The ground around the KSC is flat, and both craft are the same: once they
have come to rest, the difference between their heights is the step between the grass and the runway
deck. If the runway kept the same height relative to the ground next to it, that step would be the same
at every loading.

## The save

[`runway-kerbin.sfs`](../diag/runway-kerbin.sfs), a sandbox game of KSP 1.12.5. Copy it into the
folder of a sandbox game and load it from that game. It holds two identical craft, each a Mk1 command
pod on an empty FL-T100 tank:

- **on the grass**, landed at latitude −0.0629°, longitude −74.7277°. It is the craft you are flying
  when the save opens;
- **on the runway**, 152 m away, where the game puts a craft launched from the Spaceplane Hangar:
  latitude −0.0488°, longitude −74.7243°.

No target is set. Keep it that way: the window reads the target when there is one, and every line would
then read the same craft.

You can make your own instead: launch the craft from the Spaceplane Hangar, move it onto the grass
beside the runway with `Alt+F12 → Cheats → Set Position`, launch the same craft a second time and leave
it on the runway, then save once. Each craft must meet the conditions of
[the capsule of the loading protocol](the-protocol-loading.md): no suspension, nothing that needs a slope
to move on its own.

### The same on the Mun, with a runway placed by a mod

[`runway-mun-kk.sfs`](../diag/runway-mun-kk.sfs) holds the same two craft on the Mun, beside a runway
placed there by [Kerbal Konstructs](https://github.com/KSP-RO/Kerbal-Konstructs) 1.12.3, the mod players
use to add bases of their own. The runway is the one of the KSC, which the mod offers as a model.

The save alone does not hold the runway: Kerbal Konstructs keeps it in two files of its own. Install
Kerbal Konstructs and what it requires, copy the `GameData` folder of
[`diag/runway-mun-kk/`](../diag/runway-mun-kk/GameData/KerbalKonstructs/NewInstances/) into the folder
of KSP so that it merges with the `GameData` there, then copy and load the save as above. It holds:

- **on the ground**, landed at latitude −0.0662°, longitude −74.2867°. It is the craft you are flying
  when the save opens;
- **on the runway**, 42 m away: latitude −0.0603°, longitude −74.2973°.

The ground there is not flat, so the step between the two craft is not the height of the runway deck.
It does not need to be: it is the same two craft on the same two spots at every loading, and it would
stay the same if nothing moved.

To make your own, with the captures below taken in a game set to French:

1. **Launch the craft from the Spaceplane Hangar** and turn SAS on, so that it keeps upright when it is
   moved.

   ![The craft on the runway of the KSC](../imgs/protocols/runway/kk-create-save/000-launch.png)

   ![SAS turned on](../imgs/protocols/runway/kk-create-save/010-SAS.png)

2. **Move it to the Mun** with `Alt+F12 → Cheats → Set Position`: the Mun, latitude −0.23, longitude
   −75, pitch 90, and tick the two boxes that let a middle click set the position and skip the safety
   checks. Once it has landed, turn SAS off.

   ![Set Position, to the Mun](../imgs/protocols/runway/kk-create-save/030-cheat.png)

   ![Landed on the Mun, SAS turned off](../imgs/protocols/runway/kk-create-save/040-stabilize.png)

3. **Create a group** where the craft is: open the statics editor of Kerbal Konstructs with `Ctrl+K`,
   then *Edit Groups*, *Spawn new Group*, and *Save&Close* in the *Group Editor* that opens. Make it the
   active group with *Set Active Group*: pick it in the list and press *OK*. That list may open at the
   bottom edge of the screen; drag it up by its title.

   ![Spawn new Group, then Save&Close](../imgs/protocols/runway/kk-create-save/050-spawn-group.png)

   ![Set Active Group](../imgs/protocols/runway/kk-create-save/060-set-active-group.png)

4. **Place the runway**: under *Spawn New*, click the title *KSC Runway lv 3* — the title, not the mesh
   name on the right, which opens the model's own settings. The runway appears on the craft: drag one of
   its arrows until the craft stands on the ground beside it, then *Save&Close*.

   ![Spawn New, KSC Runway lv 3](../imgs/protocols/runway/kk-create-save/070-spawn-runway.png)

   ![The runway moved away from the craft](../imgs/protocols/runway/kk-create-save/080-move-away-from-capsule.png)

   ![Save&Close](../imgs/protocols/runway/kk-create-save/090-save-moon-runway.png)

5. **Launch the same craft a second time**: go back to the Space Center from the pause menu, launch it
   from the Spaceplane Hangar again, SAS on, and move it to the Mun with the same latitude and
   longitude. It lands a few kilometres from the runway.

   ![Back to the Space Center](../imgs/protocols/runway/kk-create-save/100-back-to-ksc.png)

   ![The second craft on the runway of the KSC](../imgs/protocols/runway/kk-create-save/110-launch-identical-capsule.png)

   ![Set Position again](../imgs/protocols/runway/kk-create-save/120-cheat-again.png)

   ![On the Mun, the runway 2.7 km away](../imgs/protocols/runway/kk-create-save/130-on-the-moon-again.png)

6. **Put it on the runway**: open *Set Position* again and middle-click the runway: latitude and
   longitude now read the spot you clicked. Press *Set Position*.

   ![Middle-click on the runway](../imgs/protocols/runway/kk-create-save/140-middle-click.png)

   ![The position of the runway, read by the middle click](../imgs/protocols/runway/kk-create-save/150-middle-click-on-runway.png)

7. **Save once**, from the pause menu, with SAS off.

   ![Save](../imgs/protocols/runway/kk-create-save/160-save.png)

## The protocol

**1. Load the save.** You are flying the craft on the grass. Wait for **Settled** to stop moving, then
press *Record*.

![The save just loaded: flying the craft on the grass, the runway 152 m away](../imgs/protocols/runway/00-grass-record.png)

**2. Switch to the craft on the runway** with `[`, one of the game's two default *switch vessel* keys.

![Switching vessel from the craft on the grass](../imgs/protocols/runway/10-next-vessel.png)

Give it three to five seconds, then press *Record*.

![After the switch: flying the craft on the runway, one line already recorded](../imgs/protocols/runway/20-runway-record.png)

**3. Load the same save again**, and repeat steps 1 and 2 — six times in all, two lines each time,
always in the same order.

⚠️ **Do not touch the throttle** of either craft. Throttling up frees a landed craft from what holds it
in place, and the next line would be measuring that.

⚠️ **Never save over the save you load.** It is what holds the heights both craft are handed back at,
and every loading must start from those same heights.

One loading says nothing on its own: it is the series that is worth reading, not a line.

On the Mun, do the same with [`runway-mun-kk.sfs`](../diag/runway-mun-kk.sfs), the craft on the ground
taking the place of the one on the grass.

# Making the save

Part of [KSP Diag - Landed Vessel](../../README.md), for [the loading protocol](../the-protocol-loading.md):
how to make a save of your own to play it on. The saves it was played on come with this mod, in
[`diag`](../../diag/README.md#the-saves-of-the-loading-protocol); you only need this page to make another.

**Two parts at least.** KSP treats a craft made of a single part apart: at every loading, it sets it back
onto the ground itself, and the reading then mixes that move with the ground's. A capsule on a small
flat fuel tank, as in the published saves, is enough. The screenshots of this page were taken with a
lone capsule; the steps are the same.

**1. Launch the craft** — no anchor, no wheels, no landing legs.

![The craft on the runway, here a lone capsule](../../imgs/protocols/reload/00-Launching.png)

(The probe window is draggable — drop it wherever it does not get in the way.)

**2. Move it off onto bare ground.** `Alt+F12 → Cheats → Set Position`. Tick *Use middle click to set
position*, then middle-click a patch of grass just off the end of the runway. No need to go far — the
KSC apron is conveniently flat — but you do have to be off the tarmac itself.

![Setting the position from the debug menu](../../imgs/protocols/reload/10-cheat-position.png)

⚠️ **Not on the launchpad and not on the runway.** It works there too — the numbers move just the
same. The trouble is that they no longer say what moved. The launchpad and the runway are structures,
not ground: KSP puts them in place its own way, and the runway's height has a wobble of its own, which
does not follow the ground's — [The measurements: the runway and the grass beside it](../the-measurements-runway.md).
A reading taken there is about the structure, not the ground. On bare terrain there is only one thing
under the craft.

⚠️ **And on flat ground.** A landed craft at rest is held in place by the game, but only while its
throttle is closed. Open it, even by a few percent, even on a craft with no engine, and nothing holds
the craft any more: on a slope it slides slowly downhill, a fraction of a millimetre per second, and
its height goes down as it slides. On flat ground it stays put. A spot is good if, once the save is
loaded, `KSP.log` has no `ground contact! - error. Moving Vessel` line naming your craft, and
**Settled** stops moving once the craft has come to rest.

Note that on some of the screenshots of this page, the throttle gauge left of the navball is not at zero:
they were taken with Shift+Win+S, and its Shift opened the throttle. Take yours with F1 or Print
Screen, which leave the throttle alone.

**3. Let it settle, and save once.**

![Creating the save](../../imgs/protocols/reload/20-create-save.png)

If you pressed *Record* before saving — out of curiosity, while placing the craft — delete that line
now. It was taken before the save existed, so its **On rails** value is the launch position and does
not belong in the same column as the others.

Then play [the protocol](../the-protocol-loading.md#the-protocol) on that save.

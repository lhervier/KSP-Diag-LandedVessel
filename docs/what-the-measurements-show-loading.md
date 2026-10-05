# What the measurements show: loading the same save

Part of [KSP Diag - Landed Vessel](../README.md): what [the measurements of loading the same save](the-measurements-loading.md)
say, on the four worlds of stock KSP and on the Moon and Earth of Real Solar System.

**On rails** gives the same digits on every line of every series, on the six bodies. So everywhere,
KSP handed the craft back where the save says it was.

**Settled** did not come back once. On every body, the craft came to rest at a height that changed from
one loading to the next: 2.3 mm on Gilly, 7.3 mm on Minmus, 18.2 mm on the Mun, 43.7 mm on Kerbin,
then 49.2 mm on the Moon of Real Solar System and 292.4 mm on its Earth. Six loadings are few, and they do not rank the worlds one by one — on the
Moon, all six happened to fall within five centimetres — but from Gilly to Earth the spread grows by two
orders of magnitude. Smaller world, smaller spread, but never none.

**On the large worlds, the spread is enough to make a craft jump, and the Moved column shows when.** It sorts
every loading into one of three cases. Wherever the ground came back more than 10 cm away from the
craft, higher or lower, the repositioning pass moved the craft onto it, up or down, before its physics
started: nothing was seen to move. Wherever the ground came back lower by less than that, the craft
dropped onto it. And wherever it came back higher by less than that — the craft a few centimetres
inside it, under the 10 cm the pass acts on — the physics engine pushed it out, as at all six loadings
of [the Moon](the-measurements-loading.md#the-readings): two jumps and two tip-overs in the twenty loadings watched for them, fourteen on the
Moon and six on Earth, two more tip-overs on the save of the Moon taken again, and, with the pass
turned off, a craft tipped over at the first loading. On the four worlds of stock KSP, the protocol
keeps to loadings where the pass never runs, so only the last two cases appear there.

**Real Solar System's workaround catches part of it, not all of it** — see
[Real Solar System's own workaround](the-measurements-loading.md#real-solar-systems-own-workaround).

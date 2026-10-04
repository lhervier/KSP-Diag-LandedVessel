using System;
using System.Collections.Generic;
using UnityEngine;
using com.github.lhervier.ksp.mcpserver;

namespace com.github.lhervier.ksp.diag.landedvessel
{
    /// <summary>
    /// What KSP-MCPServer, when it is installed, offers of this mod as tools: its buttons, the reading of
    /// its table, and the moving of its window. Each method works on the window loaded in the scene.
    /// Nothing here is needed to play by hand, and this mod runs the same without KSP-MCPServer: only
    /// that server reads the attribute.
    /// </summary>
    internal static class McpTools
    {
        [McpTool("landedvessel_record",
            "Presses Record in the window of KSP Diag - Landed Vessel: freezes the line in progress into " +
                "its table, and returns it (OnRailsMm, SettledMm, MovedMm, in millimetres from the centre " +
                "of the body; MovedMm negative downwards).")]
        internal static object Record()
        {
            return Line(Window().Record());
        }

        [McpTool("landedvessel_read",
            "Reads the window of KSP Diag - Landed Vessel: the craft it follows, its recorded lines and " +
                "the line in progress (OnRailsMm, SettledMm, MovedMm, in millimetres from the centre of " +
                "the body; MovedMm negative downwards).")]
        internal static object Read()
        {
            KSPDiagLandedVessel window = Window();
            List<object> lines = new List<object>();
            foreach (Reading reading in window.Lines)
            {
                lines.Add(Line(reading));
            }
            return new Dictionary<string, object>
            {
                { "subject", window.Subject },
                { "lines", lines },
                { "live", Line(window.Live) }
            };
        }

        [McpTool("landedvessel_clear", "Presses Clear table in the window of KSP Diag - Landed Vessel.")]
        internal static void Clear()
        {
            Window().Clear();
        }

        [McpTool("landedvessel_move_window",
            "Moves the window of KSP Diag - Landed Vessel, as dragging it does: x and y in pixels from " +
            "the top left corner of the screen. Returns its position and size (x, y, width, height).")]
        internal static object MoveWindow(double x, double y)
        {
            KSPDiagLandedVessel window = Window();
            Rect rect = window.WindowRect;
            rect.x = (float)x;
            rect.y = (float)y;
            window.WindowRect = rect;
            return new Dictionary<string, object>
            {
                { "x", (double)rect.x },
                { "y", (double)rect.y },
                { "width", (double)rect.width },
                { "height", (double)rect.height }
            };
        }

        [McpTool("landedvessel_show_window",
            "Shows or hides the window of KSP Diag - Landed Vessel, as Mod+F6 does; what it measures goes on either " +
            "way. Returns whether it shows (visible).")]
        internal static object ShowWindow(bool visible)
        {
            KSPDiagLandedVessel.WindowVisible = visible;
            return new Dictionary<string, object> { { "visible", KSPDiagLandedVessel.WindowVisible } };
        }

        // One line of the table as the tools return it: the two distances and their difference, which
        // the table shows but Reading only computes.
        private static Dictionary<string, object> Line(Reading reading)
        {
            return new Dictionary<string, object>
            {
                { "OnRailsMm", reading.OnRailsMm },
                { "SettledMm", reading.SettledMm },
                { "MovedMm", reading.MovedMm() }
            };
        }

        // The window of this mod in the current scene; the window only exists in flight.
        private static KSPDiagLandedVessel Window()
        {
            KSPDiagLandedVessel window = UnityEngine.Object.FindObjectOfType<KSPDiagLandedVessel>();
            if (window == null)
            {
                throw new InvalidOperationException("The window of KSP Diag - Landed Vessel only exists in flight");
            }
            return window;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using ImGuiNET;

namespace Starflow.Editor
{
    public class MainMenuBar : View
    {
        public static void Imgui()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("File"))
                {
                    if (ImGui.MenuItem("New"))
                    {

                    }
                    if (ImGui.MenuItem("Open"))
                    {

                    }
                    if (ImGui.MenuItem("Save"))
                    {

                    }
                    if (ImGui.MenuItem("Save As"))
                    {

                    }
                    ImGui.Separator();
                    if (ImGui.MenuItem("Exit", "Alt+F4"))
                    {
                        StarflowEditor.instance.Exit();
                    }
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Edit"))
                {
                    if (ImGui.MenuItem("Undo", "CTRL+Z"))
                    {
                        Debug.Log("na");
                    }
                    if (ImGui.MenuItem("Redo", "CTRL+Y or CTRL+ALT+Z"))
                    {
                        Debug.Log("na");
                    }
                    ImGui.Separator();
                    if (ImGui.MenuItem("Properties"))
                    { 
                    }
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("View"))
                {
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Tools"))
                {
                    ImGui.EndMenu();
                }
                if (ImGui.BeginMenu("Help"))
                {
                    ImGui.EndMenu();
                }
                ImGui.EndMainMenuBar();
            }
        }
    }
}
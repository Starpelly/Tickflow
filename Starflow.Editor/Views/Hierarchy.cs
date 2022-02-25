﻿using ImGuiNET;
using System;
using System.Collections.Generic;

namespace Starflow.Editor
{
    public class Hierarchy : View
    {
        private static int nodeClicked = 0;
        private static string payloadDragDropTyoe = "Hierarchy";

        public static void Imgui(Scene currentScene)
        {
            ImGui.Begin("Hierarchy");
            for (int i = 0; i < currentScene.gameObjects.Count; i++)
            {
                GameObject gameObject = currentScene.gameObjects[i];
                bool treeNodeOpen = doTreeNode(currentScene.gameObjects, gameObject, i);

                if (treeNodeOpen)
                {
                    ImGui.TreePop();
                }

                if (ImGui.IsItemClicked() && !ImGui.IsItemToggledOpen())
                {
                    currentScene.SetActiveGameObject(currentScene.gameObjects[i]);
                }
            }

            if (ImGui.BeginPopupContextWindow())
            {
                if (ImGui.Selectable("Create Empty"))
                {
                    currentScene.gameObjects.Add(new GameObject("GameObject"));
                }
                ImGui.EndPopup();
            }

            ImGui.End();
        }

        private unsafe static bool doTreeNode(List<GameObject> gameObjects, GameObject gameObject, int i)
        {
            ImGui.PushID(i);
            bool treeNodeOpen = ImGui.TreeNodeEx(gameObject.name, ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.FramePadding | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.SpanAvailWidth, gameObject.name);
            ImGui.PopID();

            if (ImGui.BeginDragDropSource())
            {
                ImGui.SetDragDropPayload(payloadDragDropTyoe, (IntPtr)(&i), sizeof(int));
                ImGui.Text(gameObject.name);
                ImGui.EndDragDropSource();
            }

            if (ImGui.BeginDragDropTarget())
            {
                var payloadObj = ImGui.AcceptDragDropPayload(payloadDragDropTyoe);
                if (payloadObj.NativePtr != null)
                {
                    var dataPtr = (int*)payloadObj.Data;
                    int srcIndex = dataPtr[0];

                    var srcItem = gameObjects[srcIndex];
                    gameObjects[srcIndex] = gameObjects[i];
                    gameObjects[i] = srcItem;

                    Debug.Log(gameObjects[i].name);
                }
                ImGui.EndDragDropTarget();
            }

            return treeNodeOpen;
        }
    }
}
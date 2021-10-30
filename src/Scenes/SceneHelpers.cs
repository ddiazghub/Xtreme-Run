using System;
using Godot;

public static class SceneHelpers {
    public static Main GetMain(Node node)
    {
        Node current = node;

        while (!current.Name.Equals("Main"))
        {
            current = node.GetParent();
        }

        return (Main) current;
    }
}
using Godot;
using System;
using System.Security.Cryptography;

public partial class InventoryMenu : Control
{
	private ItemList Inventory;
	private Button Slot1;
	private Button Slot2;
	private Button Slot3;
	private Button Slot4;

	private string Slot1Name;
	private string Slot2Name;
	private string Slot3Name;
	private string Slot4Name;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Inventory = GetNode<ItemList>("CenterContainer/VBoxContainer/Inventory");

		Slot1 = GetNode<Button>("CenterContainer/VBoxContainer/EquippedWeapons/Slot1");
		Slot2 = GetNode<Button>("CenterContainer/VBoxContainer/EquippedWeapons/Slot2");
		Slot3 = GetNode<Button>("CenterContainer/VBoxContainer/EquippedWeapons/Slot3");
		Slot4 = GetNode<Button>("CenterContainer/VBoxContainer/EquippedWeapons/Slot4");

		if(DataManager.Slot1 > -1)
		{
			Slot1.Icon = Inventory.GetItemIcon(DataManager.Slot1);
			Slot1Name = Inventory.GetItemText(DataManager.Slot1);
		}
		if(DataManager.Slot2 > -1)
		{
			Slot2.Icon = Inventory.GetItemIcon(DataManager.Slot2);
			Slot2Name = Inventory.GetItemText(DataManager.Slot2);
		}
		if(DataManager.Slot3 > -1)
		{
			Slot3.Icon = Inventory.GetItemIcon(DataManager.Slot3);
			Slot3Name = Inventory.GetItemText(DataManager.Slot3);
		}
		if(DataManager.Slot4 > -1)
		{
			Slot4.Icon = Inventory.GetItemIcon(DataManager.Slot4);
			Slot4Name = Inventory.GetItemText(DataManager.Slot4);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_slot_1_pressed()
	{
		if(Inventory.IsAnythingSelected())
		{
			Slot1.Icon = Inventory.GetItemIcon(Inventory.GetSelectedItems()[0]);
			Slot1Name = Inventory.GetItemText(Inventory.GetSelectedItems()[0]);
			DataManager.Slot1 = Inventory.GetSelectedItems()[0];
		}
	}

	public void _on_slot_2_pressed()
	{
		if(Inventory.IsAnythingSelected())
		{
			Slot2.Icon = Inventory.GetItemIcon(Inventory.GetSelectedItems()[0]);
			Slot2Name = Inventory.GetItemText(Inventory.GetSelectedItems()[0]);
			DataManager.Slot2 = Inventory.GetSelectedItems()[0];
		}
	}

	public void _on_slot_3_pressed()
	{
		if(Inventory.IsAnythingSelected())
		{
			Slot3.Icon = Inventory.GetItemIcon(Inventory.GetSelectedItems()[0]);
			Slot3Name = Inventory.GetItemText(Inventory.GetSelectedItems()[0]);
			DataManager.Slot3 = Inventory.GetSelectedItems()[0];
		}
	}

	public void _on_slot_4_pressed()
	{
		if(Inventory.IsAnythingSelected())
		{
			Slot4.Icon = Inventory.GetItemIcon(Inventory.GetSelectedItems()[0]);
			Slot4Name = Inventory.GetItemText(Inventory.GetSelectedItems()[0]);
			DataManager.Slot4 = Inventory.GetSelectedItems()[0];
		}
	}
}

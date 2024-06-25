using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SAM.API.Interfaces;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ISteamInventory002
{
    public IntPtr GetResultStatus;
    public IntPtr GetResultItems;
    public IntPtr GetResultTimestamp;
    public IntPtr CheckResultSteamID;
    public IntPtr DestroyResult;
    public IntPtr GetAllItems;
    public IntPtr GetItemsByID;
    public IntPtr SerializeResult;
    public IntPtr DeserializeResult;
    public IntPtr GenerateItems;
    public IntPtr GrantPromoItems;
    public IntPtr AddPromoItem;
    public IntPtr AddPromoItems;
    public IntPtr ConsumeItem;
    public IntPtr ExchangeItems;
    public IntPtr TransferItemQuantity;
    public IntPtr SendItemDropHeartbeat;
    public IntPtr TriggerItemDrop;
    public IntPtr TradeItems;
    public IntPtr LoadItemDefinitions;
    public IntPtr GetItemDefinitionIDs;
    public IntPtr GetItemDefinitionProperty;
    public IntPtr GetNumItemsWithPrices;
    private IntPtr DTorISteamInventory;
}

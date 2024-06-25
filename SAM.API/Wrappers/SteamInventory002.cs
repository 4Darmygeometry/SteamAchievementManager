using SAM.API.Interfaces;
using SAM.API.Types;
using System.Runtime.InteropServices;

namespace SAM.API.Wrappers
{
    public class SteamInventory002 : NativeWrapper<ISteamInventory002>
    {
        #region GetAllItems
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetAllItems(IntPtr self, ref IntPtr pResultHandle);

        public bool GetAllItems(ref IntPtr pResultHandle)
        {
            return GetFunction<NativeGetAllItems>(Functions.TriggerItemDrop)
                (ObjectAddress, ref pResultHandle);
        }
        #endregion

        #region GetResultItems
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetResultItems(IntPtr self, IntPtr pResultHandle, [In, Out] SteamInventoryResult pOutItemsArray, ref uint punOutItemsArraySize);

        public bool GetResultItems(IntPtr pResultHandle, [In, Out] SteamInventoryResult pOutItemsArray, ref uint punOutItemsArraySize)
        {
            return GetFunction<NativeGetResultItems>(Functions.GetResultItems)
                (ObjectAddress, pResultHandle, pOutItemsArray, ref punOutItemsArraySize);
        }
        #endregion

        #region GetNumItemsWithPrices
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetNumItemsWithPrices(IntPtr self);

        public bool GetNumItemsWithPrices()
        {
            return GetFunction<NativeGetNumItemsWithPrices>(Functions.GetNumItemsWithPrices)
                (ObjectAddress);
        }
        #endregion

        #region DestroyResult
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeDestroyResult(IntPtr self, IntPtr resultHandle);

        public bool DestroyResult(IntPtr resultHandle)
        {
            return GetFunction<NativeDestroyResult>(Functions.DestroyResult)
                (ObjectAddress, resultHandle);
        }
        #endregion

        #region GetItemDefinitionIDs
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetItemDefinitionIDs(IntPtr self, ref uint pItemDefIDs, ref uint punItemDefIDsArraySize);

        public bool GetItemDefinitionIDs(ref uint pItemDefIDs, ref uint punItemDefIDsArraySize)
        {
            return GetFunction<NativeGetItemDefinitionIDs>(Functions.GetItemDefinitionIDs)
                (ObjectAddress, ref pItemDefIDs, ref punItemDefIDsArraySize);
        }
        #endregion

        #region TriggerItemDrop
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeTriggerItemDrop(IntPtr self, ref IntPtr pResultHandle, uint dropListDefinition);

        public bool TriggerItemDrop(ref IntPtr pResultHandle, uint dropListDefinition)
        {
            return GetFunction<NativeTriggerItemDrop>(Functions.TriggerItemDrop)
                (ObjectAddress, ref pResultHandle, dropListDefinition);
        }
        #endregion
    }
}

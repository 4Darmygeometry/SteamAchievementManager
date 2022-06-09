/* Copyright (c) 2019 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using SAM.API.Interfaces;
using SAM.API.Types;
using System;
using System.Runtime.InteropServices;

namespace SAM.API.Wrappers
{
    public class SteamRemoteStorage012 : NativeWrapper<ISteamRemoteStorage014>
    {
        #region FileWrite
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFileWriteSBI(IntPtr self, string pchFile, Byte[] pvData, int cubData);

        public bool FileWrite(string pchFile, Byte[] pvData)
        {
            return this.GetFunction<NativeFileWriteSBI>(this.Functions.FileWrite)
                (this.ObjectAddress, pchFile, pvData, pvData.Length);
        }
        #endregion

        #region FileWrite
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeFileReadSBI(IntPtr thisptr, string pchFile, Byte[] pvData, int cubDataToRead);

        public int FileRead(string pchFile, Byte[] pvData)
        {
            return this.GetFunction<NativeFileReadSBI>(this.Functions.FileRead)
                (this.ObjectAddress, pchFile, pvData, pvData.Length);
        }
        #endregion

        #region FileForget
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFileForgetS(IntPtr thisptr, string pchFile);

        public bool FileForget(string pchFile)
        {
            return this.Call<bool, NativeFileForgetS>(this.Functions.FileForget, this.ObjectAddress, pchFile);
        }
        #endregion

        #region FileDelete
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFileDeleteS(IntPtr thisptr, string pchFile);

        public bool FileDelete(string pchFile)
        {
            return this.Call<bool, NativeFileDeleteS>(this.Functions.FileDelete, this.ObjectAddress, pchFile);
        }
        #endregion

        #region SetSyncPlatforms
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeSetSyncPlatformsSE(IntPtr thisptr, string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform);

        public bool SetSyncPlatforms(string pchFile, ERemoteStoragePlatform eRemoteStoragePlatform)
        {
            return this.Call<bool, NativeSetSyncPlatformsSE>(this.Functions.SetSyncPlatforms, this.ObjectAddress, pchFile, eRemoteStoragePlatform);
        }
        #endregion

        #region FileExists
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFileExistsS(IntPtr thisptr, string pchFile);

        public bool FileExists(string pchFile)
        {
            return this.Call<bool, NativeFileExistsS>(this.Functions.FileExists, this.ObjectAddress, pchFile);
        }
        #endregion

        #region FilePersisted
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeFilePersistedS(IntPtr thisptr, string pchFile);

        public bool FilePersisted(string pchFile)
        {
            return this.Call<bool, NativeFilePersistedS>(this.Functions.FilePersisted, this.ObjectAddress, pchFile);
        }
        #endregion

        #region GetFileSize
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetFileSizeS(IntPtr thisptr, string pchFile);

        public int GetFileSize(string pchFile)
        {
            return this.Call<int, NativeGetFileSizeS>(this.Functions.GetFileSize, this.ObjectAddress, pchFile);
        }
        #endregion

        #region GetFileTimestamp
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate long NativeGetFileTimestampS(IntPtr thisptr, string pchFile);

        public long GetFileTimestamp(string pchFile)
        {
            return this.Call<long, NativeGetFileTimestampS>(this.Functions.GetFileTimestamp, this.ObjectAddress, pchFile);
        }
        #endregion

        #region GetSyncPlatforms
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate ERemoteStoragePlatform NativeGetSyncPlatformsS(IntPtr thisptr, string pchFile);

        public ERemoteStoragePlatform GetSyncPlatforms(string pchFile)
        {
            return this.Call<ERemoteStoragePlatform, NativeGetSyncPlatformsS>(this.Functions.GetSyncPlatforms, this.ObjectAddress, pchFile);
        }
        #endregion

        #region GetFileCount
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate int NativeGetFileCount(IntPtr thisptr);

        public int GetFileCount()
        {
            return this.Call<int, NativeGetFileCount>(this.Functions.GetFileCount, this.ObjectAddress);
        }
        #endregion

        #region GetFileNameAndSize
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate IntPtr NativeGetFileNameAndSizeII(IntPtr thisptr, int iFile, out int pnFileSizeInBytes);

        public string GetFileNameAndSize(int iFile, out int pnFileSizeInBytes)
        {
            return NativeStrings.PointerToString(
                this.GetFunction<NativeGetFileNameAndSizeII>(
                    this.Functions.GetFileNameAndSize)(this.ObjectAddress, iFile, out pnFileSizeInBytes));
        }
        #endregion

        #region GetQuota
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeGetQuota(IntPtr thisptr, out ulong pnTotalBytes, out ulong puAvailableBytes);

        public bool GetQuota(out ulong pnTotalBytes, out ulong puAvailableBytes)
        {
            return this.GetFunction<NativeGetQuota>(this.Functions.GetQuota)(this.ObjectAddress, out pnTotalBytes, out puAvailableBytes);
        }
        #endregion

        #region IsCloudEnabledForAccount
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsCloudEnabledForAccount(IntPtr thisptr);


        public bool IsCloudEnabledForAccount()
        {
            return this.Call<bool, NativeIsCloudEnabledForAccount>(this.Functions.IsCloudEnabledForAccount, this.ObjectAddress);
        }
        #endregion

        #region IsCloudEnabledForApp
        [return: MarshalAs(UnmanagedType.I1)]
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool NativeIsCloudEnabledForApp(IntPtr thisptr);

        public bool IsCloudEnabledForApp()
        {
            return this.Call<bool, NativeIsCloudEnabledForApp>(this.Functions.IsCloudEnabledForApp, this.ObjectAddress);
        }
        #endregion

        #region SetCloudEnabledForApp
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void NativeSetCloudEnabledForAppB(IntPtr thisptr, [MarshalAs(UnmanagedType.I1)] bool bEnabled);

        public void SetCloudEnabledForApp(bool bEnabled)
        {
            this.Call<NativeSetCloudEnabledForAppB>(this.Functions.SetCloudEnabledForApp, this.ObjectAddress, bEnabled);
        }
        #endregion

    }
}
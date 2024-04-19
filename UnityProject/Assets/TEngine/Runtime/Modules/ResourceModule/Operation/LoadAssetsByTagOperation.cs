﻿using System.Collections.Generic;
using UnityEngine;
using YooAsset;

namespace TEngine
{
    /// <summary>
    /// 通过资源标识加载资源。
    /// </summary>
    /// <typeparam name="TObject">资源实例类型。</typeparam>
    public class LoadAssetsByTagOperation<TObject> : GameAsyncOperation where TObject : UnityEngine.Object
    {
        private enum ESteps
        {
            None,
            LoadAssets,
            CheckResult,
            Done,
        }

        private readonly string _tag;
        private readonly string _packageName; // 指定资源包的名称
        private ESteps _steps = ESteps.None;
        private List<AssetOperationHandle> _handles;

        /// <summary>
        /// 资源对象集合
        /// </summary>
        public List<TObject> AssetObjects { private set; get; }


        public LoadAssetsByTagOperation(string tag, string packageName)
        {
            _tag = tag;
            _packageName = packageName;
        }

        protected override void OnStart()
        {
            _steps = ESteps.LoadAssets;
        }

        protected override void OnUpdate()
        {
            if (_steps == ESteps.None || _steps == ESteps.Done)
                return;

            if (_steps == ESteps.LoadAssets)
            {
                AssetInfo[] assetInfos;
                if (string.IsNullOrEmpty(_packageName))
                {
                    assetInfos = YooAssets.GetAssetInfos(_tag);
                }
                else
                {
                    var package = YooAssets.GetPackage(_packageName);
                    assetInfos = package.GetAssetInfos(_tag);
                }

                _handles = new List<AssetOperationHandle>(assetInfos.Length);

                foreach (var assetInfo in assetInfos)
                {
                    AssetOperationHandle handle;
                    if (string.IsNullOrEmpty(_packageName))
                    {
                        handle = YooAssets.LoadAssetAsync(assetInfo);
                    }
                    else
                    {
                        var package = YooAssets.GetPackage(_packageName);
                        handle = package.LoadAssetAsync(assetInfo);
                    }

                    _handles.Add(handle);
                }

                _steps = ESteps.CheckResult;
            }

            if (_steps == ESteps.CheckResult)
            {
                int index = 0;
                foreach (var handle in _handles)
                {
                    if (handle.IsDone == false)
                    {
                        Progress = (float)index / _handles.Count;
                        return;
                    }

                    index++;
                }

                AssetObjects = new List<TObject>(_handles.Count);
                foreach (var handle in _handles)
                {
                    if (handle.Status == EOperationStatus.Succeed)
                    {
                        var assetObject = handle.AssetObject as TObject;
                        if (assetObject != null)
                        {
                            AssetObjects.Add(assetObject);
                        }
                        else
                        {
                            string error = $"资源类型转换失败：{handle.AssetObject.name}";
                            Debug.LogError($"{error}");
                            AssetObjects.Clear();
                            SetFinish(false, error);
                            return;
                        }
                    }
                    else
                    {
                        Debug.LogError($"{handle.LastError}");
                        AssetObjects.Clear();
                        SetFinish(false, handle.LastError);
                        return;
                    }
                }

                SetFinish(true);
            }
        }

        private void SetFinish(bool succeed, string error = "")
        {
            Error = error;
            Status = succeed ? EOperationStatus.Succeed : EOperationStatus.Failed;
            _steps = ESteps.Done;
        }

        /// <summary>
        /// 释放资源句柄
        /// </summary>
        public void ReleaseHandle()
        {
            foreach (var handle in _handles)
            {
                handle.Release();
            }

            _handles.Clear();
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Polygons.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
    internal sealed partial class PolygonGaSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static PolygonGaSettings defaultInstance = ((PolygonGaSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new PolygonGaSettings())));
        
        public static PolygonGaSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.4")]
        public double MaximumDistanceMutation {
            get {
                return ((double)(this["MaximumDistanceMutation"]));
            }
            set {
                this["MaximumDistanceMutation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("45")]
        public int MaximumAngleMutation {
            get {
                return ((int)(this["MaximumAngleMutation"]));
            }
            set {
                this["MaximumAngleMutation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("12")]
        public int PolygonVertices {
            get {
                return ((int)(this["PolygonVertices"]));
            }
            set {
                this["PolygonVertices"] = value;
            }
        }
    }
}

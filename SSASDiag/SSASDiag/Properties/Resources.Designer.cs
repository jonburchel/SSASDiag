﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSASDiag.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SSASDiag.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] ASProfilerTraceImporterCmd {
            get {
                object obj = ResourceManager.GetObject("ASProfilerTraceImporterCmd", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Backup xmlns=&quot;http://schemas.microsoft.com/analysisservices/2003/engine&quot;&gt;
        ///  &lt;Object&gt;
        ///    &lt;DatabaseID/&gt;
        ///  &lt;/Object&gt;
        ///  &lt;File/&gt;
        ///  &lt;AllowOverwrite/&gt;
        ///&lt;/Backup&gt;.
        /// </summary>
        internal static string BackupDbXMLA {
            get {
                return ResourceManager.GetString("BackupDbXMLA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF  NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N&apos;&lt;dbname/&gt;&apos;)
        ///CREATE DATABASE [&lt;dbname/&gt;]
        /// CONTAINMENT = NONE
        /// ON  PRIMARY 
        ///( NAME = N&apos;test&apos;, FILENAME = N&apos;&lt;mdfpath/&gt;&apos; , SIZE = 4096KB , FILEGROWTH = 1024KB )
        /// LOG ON 
        ///( NAME = N&apos;test_log&apos;, FILENAME = N&apos;&lt;ldfpath/&gt;&apos; , SIZE = 1024KB , FILEGROWTH = 10%)
        ///.
        /// </summary>
        internal static string CreateDBSQLScript {
            get {
                return ResourceManager.GetString("CreateDBSQLScript", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Batch xmlns=&quot;http://schemas.microsoft.com/analysisservices/2003/engine&quot; xmlns:soap=&quot;http://schemas.xmlsoap.org/soap/envelope/&quot;&gt;
        ///	&lt;Create xmlns=&quot;http://schemas.microsoft.com/analysisservices/2003/engine&quot;&gt;
        ///		&lt;ObjectDefinition&gt;
        ///			&lt;Trace&gt;
        ///				&lt;LogFileName/&gt;
        ///				&lt;ID/&gt;
        ///				&lt;LogFileSize/&gt;
        ///				&lt;LogFileRollover/&gt;
        ///				&lt;Name/&gt;
        ///				&lt;AutoRestart/&gt;
        ///				&lt;StartTime/&gt;
        ///				&lt;StopTime/&gt;
        ///				&lt;LogFileAppend&gt;false&lt;/LogFileAppend&gt;
        ///				&lt;Events&gt;
        ///					&lt;Event&gt;
        ///						&lt;EventID&gt;15&lt;/EventID&gt;
        ///						&lt;Columns&gt;
        ///							&lt;Colu [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DbsCapturedTraceStartXMLA {
            get {
                return ResourceManager.GetString("DbsCapturedTraceStartXMLA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N&apos;[dbo].[ProfilerEventClass]&apos;) AND type in (N&apos;U&apos;)) DROP TABLE [dbo].[ProfilerEventClass]; CREATE TABLE [dbo].[ProfilerEventClass]([EventClassID] [int] NOT NULL, [Name] [nvarchar](50) NULL, [Description] [nvarchar](500) NULL, CONSTRAINT [PK_ProfilerEventClass] PRIMARY KEY CLUSTERED ([EventClassID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMAR [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string EventClassSubClassTablesScript {
            get {
                return ResourceManager.GetString("EventClassSubClassTablesScript", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] ExtractDbNamesFromTraceCmd {
            get {
                object obj = ResourceManager.GetObject("ExtractDbNamesFromTraceCmd", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap heart {
            get {
                object obj = ResourceManager.GetObject("heart", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon Microsoft_107 {
            get {
                object obj = ResourceManager.GetObject("Microsoft_107", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon ntshrui_3029 {
            get {
                object obj = ResourceManager.GetObject("ntshrui_3029", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap package_new {
            get {
                object obj = ResourceManager.GetObject("package_new", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap play {
            get {
                object obj = ResourceManager.GetObject("play", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap play_half_lit {
            get {
                object obj = ResourceManager.GetObject("play_half_lit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap play_lit {
            get {
                object obj = ResourceManager.GetObject("play_lit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Batch xmlns=&quot;http://schemas.microsoft.com/analysisservices/2003/engine&quot; xmlns:soap=&quot;http://schemas.xmlsoap.org/soap/envelope/&quot;&gt;
        ///	&lt;Create xmlns=&quot;http://schemas.microsoft.com/analysisservices/2003/engine&quot;&gt;
        ///		&lt;ObjectDefinition&gt;
        ///			&lt;Trace&gt;
        ///				&lt;LogFileName/&gt;
        ///				&lt;ID/&gt;
        ///				&lt;LogFileSize/&gt;&lt;LogFileRollover/&gt;
        ///				&lt;Name/&gt;
        ///				&lt;AutoRestart/&gt;&lt;StartTime/&gt;&lt;StopTime/&gt;
        ///				&lt;LogFileAppend&gt;false&lt;/LogFileAppend&gt;
        ///				&lt;Events&gt;&lt;Event&gt;&lt;EventID&gt;15&lt;/EventID&gt;&lt;Columns&gt;&lt;ColumnID&gt;32&lt;/ColumnID&gt;&lt;ColumnID&gt;1&lt;/ColumnID&gt;&lt;ColumnID&gt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ProfilerTraceStartWithQuerySubcubeEventsXMLA {
            get {
                return ResourceManager.GetString("ProfilerTraceStartWithQuerySubcubeEventsXMLA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Batch xmlns=&quot;http://schemas.microsoft.com/analysisservices/2003/engine&quot; xmlns:soap=&quot;http://schemas.xmlsoap.org/soap/envelope/&quot;&gt;
        ///	&lt;Create xmlns=&quot;http://schemas.microsoft.com/analysisservices/2003/engine&quot;&gt;
        ///		&lt;ObjectDefinition&gt;
        ///			&lt;Trace&gt;
        ///				&lt;LogFileName/&gt;
        ///				&lt;ID/&gt;
        ///				&lt;LogFileSize/&gt;&lt;LogFileRollover/&gt;
        ///				&lt;Name/&gt;
        ///				&lt;AutoRestart/&gt;&lt;StartTime/&gt;&lt;StopTime/&gt;
        ///				&lt;LogFileAppend&gt;false&lt;/LogFileAppend&gt;
        ///				&lt;Events&gt;
        ///					&lt;Event&gt;
        ///						&lt;EventID&gt;15&lt;/EventID&gt;
        ///						&lt;Columns&gt;
        ///							&lt;ColumnID&gt;32&lt;/ColumnID&gt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ProfilerTraceStartXMLA {
            get {
                return ResourceManager.GetString("ProfilerTraceStartXMLA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Delete xmlns=&quot;http://schemas.microsoft.com/analysisservices/2003/engine&quot; xmlns:soap=&quot;http://schemas.xmlsoap.org/soap/envelope/&quot;&gt;
        ///	&lt;Object&gt;
        ///		&lt;TraceID/&gt;
        ///	&lt;/Object&gt;
        ///&lt;/Delete&gt;.
        /// </summary>
        internal static string ProfilerTraceStopXMLA {
            get {
                return ResourceManager.GetString("ProfilerTraceStopXMLA", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Progress {
            get {
                object obj = ResourceManager.GetObject("Progress", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] ResourcesZip {
            get {
                object obj = ResourceManager.GetObject("ResourcesZip", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon SHELL32_324 {
            get {
                object obj = ResourceManager.GetObject("SHELL32_324", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap stop_button_half_lit {
            get {
                object obj = ResourceManager.GetObject("stop_button_half_lit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap stop_button_lit {
            get {
                object obj = ResourceManager.GetObject("stop_button_lit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap stop_button_th {
            get {
                object obj = ResourceManager.GetObject("stop_button_th", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}

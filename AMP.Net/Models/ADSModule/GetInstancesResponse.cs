using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AMP.Net.Models
{
    public class GetInstancesResponse
    {
        public int Id { get; set; }
        public Guid InstanceId { get; set; }

        public string FriendlyName { get; set; }

        public string Description { get; set; }

        public bool Disabled { get; set; }

        public PlatformInfo Platform { get; set; }

        public int State { get; set; }

        public bool CanCreate { get; set; }

        [JsonConverter(typeof(MicrosoftJsonDateConverter))]
        public DateTime LastUpdated { get; set; }

        public IList<InstanceInfo> AvailableInstances { get; set; }

        public IList<string> AvailableIPs { get; set; }
    }

    public class InstanceInfo
    {
        [JsonPropertyName("InstanceID")]
        public Guid InstanceId { get; set; }
        
        [JsonPropertyName("TargetID")]
        public Guid TargetId { get; set; }
        
        public string InstanceName { get; set; }
        
        public string FriendlyName { get; set; }
        
        public string Module { get; set; }
        
        public Version InstalledVersion { get; set; }
        
        [JsonPropertyName("IsHTTPS")]
        public bool IsHttps { get; set; }
        
        public string IP { get; set; }
        
        public uint Port { get; set; }
        
        public bool Daemon { get; set; }
        
        public bool DaemonAutostart { get; set; }
        
        public bool ExcludeFromFirewall { get; set; }
        
        public bool Running { get; set; }
        
        public int AppState { get; set; }
        
        public int ReleaseStream { get; set; }
        
        public int ManagementMode { get; set; }
        
        public bool Suspended { get; set; }
        
        public bool IsTemplateInstance { get; set; }

        public string ApplicationEndpoint { get; set; }
    }

    public class PlatformInfo
    {
        public bool IsSharedSetup { get; set; }

        public int OS { get; set; }

        public int Virtualization { get; set; }

        public int SystemType { get; set; }

        public string PlatformName { get; set; }

        [JsonPropertyName("CPUInfo")]
        public CpuInfo CpuInfo { get; set; }

        [JsonPropertyName("InstalledRAMMB")]
        public int InstalledRam { get; set; }

        public Version InstalledGlibcVersion { get; set; }

        public int AdminRights { get; set; }
    }

    public class CpuInfo
    {
        public int Sockets { get; set; }

        public int Cores { get; set; }

        public int Threads { get; set; }

        public string Vendor { get; set; }

        public string ModelName { get; set; }

        public int TotalCores { get; set; }

        public int TotalThreads { get; set; }
    }
}

# Zamin.Extensions.Serializers.Abstractions

**Types in this pattern:** `IJsonSerializer`.

## Registration

`AddZaminMicrosoftSerializer()` in host `HostingExtensions`.

## Usage

Injected into infra such as Duende `DeviceFlowStore` (ctor parameter `IJsonSerializer jsonSerializer`).

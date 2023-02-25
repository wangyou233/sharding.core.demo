using EFCore.Sharding.Demo.Entities;
using ShardingCore.Core.EntityMetadatas;
using ShardingCore.VirtualRoutes.Mods;

namespace EFCore.Sharding.Demo.TableRoutes;

public class UnitVirtualTableRoute:AbstractSimpleShardingModKeyStringVirtualTableRoute<Unit>
{
    public UnitVirtualTableRoute() : base(2,3)
    {
    }

    public override void Configure(EntityMetadataTableBuilder<Unit> builder)
    {
        builder.ShardingProperty(x => x.Id);
        builder.TableSeparator("_");
    }
}
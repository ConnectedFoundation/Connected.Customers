using Connected.Caching;
using Connected.Storage;

namespace Connected.Customers.Service.Desks;

internal sealed class DeskCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<Desk, int>(cache, storage, ServiceMetaData.DeskKey), IDeskCache
{
}

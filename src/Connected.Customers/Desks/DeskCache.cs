using Connected.Caching;
using Connected.Storage;

namespace Connected.Customers.Desks;

internal sealed class DeskCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<IDesk, Desk, int>(cache, storage, ServiceMetaData.DeskKey), IDeskCache
{
}

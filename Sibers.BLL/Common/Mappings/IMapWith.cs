using AutoMapper;

namespace Sibers.BLL.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile);
    }
}

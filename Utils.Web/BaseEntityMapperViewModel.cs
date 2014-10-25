using AutoMapper;

namespace Utils.Web
{
    /// <summary>
    /// Allows to map a ViewModel to/from a Domain Entity.
    /// </summary>
    /// <typeparam name="TViewModel">Type of the view model</typeparam>
    /// <typeparam name="TEntity">Type of the entity</typeparam>
    public abstract class BaseEntityMapperViewModel<TViewModel, TEntity>
        where TEntity : class
        where TViewModel : class
    {
        /// <summary>
        /// Initializes the <see cref="BaseEntityMapperViewModel{TViewModel,TEntity}"/> class.
        /// </summary>
        static BaseEntityMapperViewModel()
        {
            Mapper.CreateMap<TViewModel, TEntity>();
            Mapper.CreateMap<TEntity, TViewModel>();
        }

        /// <summary>
        /// Maps the specified view model to a entity object.
        /// </summary>
        public TEntity MapToEntity()
        {
            // Map the derived class to the represented view model
            return Mapper.Map<TEntity>(CastToDerivedClass(this));
        }

        /// <summary>
        /// Maps a entity to a view model instance.
        /// </summary>
        public static TViewModel MapFromEntity(TEntity model)
        {
            return Mapper.Map<TViewModel>(model);
        }

        #region Private

        /// <summary>
        /// Gets the derived class.
        /// </summary>
        private static TViewModel CastToDerivedClass(BaseEntityMapperViewModel<TViewModel, TEntity> baseInstance)
        {
            return Mapper.Map<TViewModel>(baseInstance);
        }

        #endregion
    }
}
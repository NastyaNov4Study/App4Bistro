//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Архив_Приготовление
    {
        public int Код_приготовления { get; set; }
        public Nullable<int> Код_блюда { get; set; }
        public Nullable<int> Количество_порций { get; set; }
        public Nullable<System.DateTime> Дата_приготовления { get; set; }
    
        public virtual Архив_Блюда Архив_Блюда { get; set; }
    }
}

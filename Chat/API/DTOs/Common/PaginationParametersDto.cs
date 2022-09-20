﻿namespace API.DTOs.Common
{
    public class PaginationParametersDto
    {
        private readonly int maxPageSize = 25;

        private int _pageSize = 25;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}

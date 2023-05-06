﻿using ExchangeRateUpdater.DataSources;
using Microsoft.Extensions.Configuration;

namespace ExchangeRateUpdater.Interfaces
{
    public interface IExchangeRateDataSourceOptionsBuilder
    {
        IExchangeRateDataSourceOptions Build();
    }

    public class ExchangeRateDataSourceOptionsBuilder : IExchangeRateDataSourceOptionsBuilder

    {
        private readonly IConfiguration configuration;

        public ExchangeRateDataSourceOptionsBuilder()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public IExchangeRateDataSourceOptions Build()
        {
            return (IExchangeRateDataSourceOptions)new ExchangeRateDataSourceOptionsWrapper
            {
                DailyRatesUrl = configuration["ExchangeRateUrls:DailyRates"],
                MonthlyRatesUrl = configuration["ExchangeRateUrls:MonthlyRates"],
            };
        }

    }
}

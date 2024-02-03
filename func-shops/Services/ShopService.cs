using func_shops.Models;
using func_shops.Settings;
using Npgsql;

namespace func_shops.Services;

public class ShopService : IShopService
{
    private readonly AppSettings _appSettings;

    public ShopService(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public async Task UpsertShopAsync(Shop shop)
    {
        await using var dbConnection = new NpgsqlConnection(_appSettings.DatabaseConnectionString);
        await dbConnection.OpenAsync();
        
        var sqlCommand = new NpgsqlCommand(@"
            INSERT INTO shops 
            (
                shop_id, name, email, domain, province, country, 
                address1, zip, city, source, phone, latitude, 
                longitude, primary_locale, address2, created_at, 
                updated_at, country_code, country_name, currency, 
                customer_email, timezone, iana_timezone, shop_owner, 
                money_format, money_with_currency_format, weight_unit, 
                province_code, taxes_included, auto_configure_tax_inclusivity, 
                tax_shipping, county_taxes, plan_display_name, plan_name, 
                has_discounts, has_gift_cards, myshopify_domain, google_apps_domain, 
                google_apps_login_enabled, money_in_emails_format, 
                money_with_currency_in_emails_format, eligible_for_payments, 
                requires_extra_payments_agreement, password_enabled, 
                has_storefront, finances, primary_location_id, 
                checkout_api_supported, multi_location_enabled, setup_required, 
                pre_launch_enabled, enabled_presentment_currencies, 
                transactional_sms_disabled, marketing_sms_consent_enabled_at_checkout, 
                access_token, installation_status, protection_percentage, 
                minimum_protection_cost
            ) 
            VALUES 
            (
                @shop_id, @name, @email, @domain, @province, @country, 
                @address1, @zip, @city, @source, @phone, @latitude, 
                @longitude, @primary_locale, @address2, @created_at, 
                @updated_at, @country_code, @country_name, @currency, 
                @customer_email, @timezone, @iana_timezone, @shop_owner, 
                @money_format, @money_with_currency_format, @weight_unit, 
                @province_code, @taxes_included, @auto_configure_tax_inclusivity, 
                @tax_shipping, @county_taxes, @plan_display_name, @plan_name, 
                @has_discounts, @has_gift_cards, @myshopify_domain, @google_apps_domain, 
                @google_apps_login_enabled, @money_in_emails_format, 
                @money_with_currency_in_emails_format, @eligible_for_payments, 
                @requires_extra_payments_agreement, @password_enabled, 
                @has_storefront, @finances, @primary_location_id, 
                @checkout_api_supported, @multi_location_enabled, @setup_required, 
                @pre_launch_enabled, @enabled_presentment_currencies, 
                @transactional_sms_disabled, @marketing_sms_consent_enabled_at_checkout, 
                @access_token, @installation_status, @protection_percentage, 
                @minimum_protection_cost
            )", dbConnection);

        sqlCommand.Parameters.AddWithValue("@shop_id", shop.ShopId);
        sqlCommand.Parameters.AddWithValue("@name", shop.Name);
        sqlCommand.Parameters.AddWithValue("@email", shop.Email ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@domain", shop.Domain);
        sqlCommand.Parameters.AddWithValue("@province", shop.Province ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@country", shop.Country ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@address1", shop.Address1 ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@zip", shop.Zip ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@city", shop.City ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@source", shop.Source ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@phone", shop.Phone ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@latitude", shop.Latitude ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@longitude", shop.Longitude ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@primary_locale", shop.PrimaryLocale);
        sqlCommand.Parameters.AddWithValue("@address2", shop.Address2 ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@created_at", shop.CreatedAt);
        sqlCommand.Parameters.AddWithValue("@updated_at", shop.UpdatedAt);
        sqlCommand.Parameters.AddWithValue("@country_code", shop.CountryCode ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@country_name", shop.CountryName ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@currency", shop.Currency);
        sqlCommand.Parameters.AddWithValue("@customer_email", shop.CustomerEmail);
        sqlCommand.Parameters.AddWithValue("@timezone", shop.Timezone);
        sqlCommand.Parameters.AddWithValue("@iana_timezone", shop.IanaTimezone);
        sqlCommand.Parameters.AddWithValue("@shop_owner", shop.ShopOwner);
        sqlCommand.Parameters.AddWithValue("@money_format", shop.MoneyFormat);
        sqlCommand.Parameters.AddWithValue("@money_with_currency_format", shop.MoneyWithCurrencyFormat);
        sqlCommand.Parameters.AddWithValue("@weight_unit", shop.WeightUnit);
        sqlCommand.Parameters.AddWithValue("@province_code", shop.ProvinceCode ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@taxes_included", shop.TaxesIncluded);
        sqlCommand.Parameters.AddWithValue("@auto_configure_tax_inclusivity", shop.AutoConfigureTaxInclusivity ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@tax_shipping", shop.TaxShipping ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@county_taxes", shop.CountyTaxes ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@plan_display_name", shop.PlanDisplayName ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@plan_name", shop.PlanName ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@has_discounts", shop.HasDiscounts);
        sqlCommand.Parameters.AddWithValue("@has_gift_cards", shop.HasGiftCards);
        sqlCommand.Parameters.AddWithValue("@myshopify_domain", shop.MyShopifyDomain);
        sqlCommand.Parameters.AddWithValue("@google_apps_domain", shop.GoogleAppsDomain ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@google_apps_login_enabled", shop.GoogleAppsLoginEnabled ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@money_in_emails_format", shop.MoneyInEmailsFormat ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@money_with_currency_in_emails_format", shop.MoneyWithCurrencyInEmailsFormat ?? (object)DBNull.Value);
        sqlCommand.Parameters.AddWithValue("@eligible_for_payments", shop.EligibleForPayments);
        sqlCommand.Parameters.AddWithValue("@requires_extra_payments_agreement", shop.RequiresExtraPaymentsAgreement);
        sqlCommand.Parameters.AddWithValue("@password_enabled", shop.PasswordEnabled);
        sqlCommand.Parameters.AddWithValue("@has_storefront", shop.HasStorefront);
        sqlCommand.Parameters.AddWithValue("@finances", shop.Finances);
        sqlCommand.Parameters.AddWithValue("@primary_location_id", shop.PrimaryLocationId);
        sqlCommand.Parameters.AddWithValue("@checkout_api_supported", shop.CheckoutApiSupported);
        sqlCommand.Parameters.AddWithValue("@multi_location_enabled", shop.MultiLocationEnabled);
        sqlCommand.Parameters.AddWithValue("@setup_required", shop.SetupRequired);
        sqlCommand.Parameters.AddWithValue("@pre_launch_enabled", shop.PreLaunchEnabled);
        sqlCommand.Parameters.AddWithValue("@enabled_presentment_currencies", shop.EnabledPresentmentCurrencies.ToArray());
        sqlCommand.Parameters.AddWithValue("@transactional_sms_disabled", shop.TransactionalSmsDisabled);
        sqlCommand.Parameters.AddWithValue("@marketing_sms_consent_enabled_at_checkout", shop.MarketingSmsConsentEnabledAtCheckout);
        sqlCommand.Parameters.AddWithValue("@access_token", shop.Accesstoken);
        sqlCommand.Parameters.AddWithValue("@installation_status", shop.InstallationStatus);
        sqlCommand.Parameters.AddWithValue("@protection_percentage", shop.ProtectionPercentage);
        sqlCommand.Parameters.AddWithValue("@minimum_protection_cost", shop.MinimumProtectionCost);

        await sqlCommand.ExecuteNonQueryAsync();
    }
}
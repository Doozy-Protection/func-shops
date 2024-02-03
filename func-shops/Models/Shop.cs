using System.Text.Json.Serialization;
using func_shops.Helpers;

namespace func_shops.Models;

public record Shop
{
    private DateTime _createdAt;
    private DateTime _updatedAt;
    
    [JsonPropertyName("id")]
    [JsonConverter(typeof(NumericStringConverter))]
    public string ShopId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; }

    [JsonPropertyName("domain")]
    public string Domain { get; init; }

    [JsonPropertyName("province")]
    public string? Province { get; init; }

    [JsonPropertyName("country")]
    public string? Country { get; init; }

    [JsonPropertyName("address1")]
    public string? Address1 { get; init; }

    [JsonPropertyName("zip")]
    public string? Zip { get; init; }

    [JsonPropertyName("city")]
    public string? City { get; init; }

    [JsonPropertyName("source")]
    public string? Source { get; init; }

    [JsonPropertyName("phone")]
    public string? Phone { get; init; }

    [JsonPropertyName("latitude")]
    [JsonConverter(typeof(NumericStringConverter))]
    public string? Latitude { get; init; }

    [JsonPropertyName("longitude")]
    [JsonConverter(typeof(NumericStringConverter))]
    public string? Longitude { get; init; }

    [JsonPropertyName("primary_locale")]
    public string PrimaryLocale { get; init; }

    [JsonPropertyName("address2")]
    public string? Address2 { get; init; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt
    {
        get => _createdAt;
        init => _createdAt = value.Kind == DateTimeKind.Unspecified
            ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
            : value.ToUniversalTime();
    }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt
    {
        get => _updatedAt;
        init => _updatedAt = value.Kind == DateTimeKind.Unspecified
            ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
            : value.ToUniversalTime();
    }

    /*[JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; init; }*/

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; init; }

    [JsonPropertyName("country_name")]
    public string? CountryName { get; init; }

    [JsonPropertyName("currency")]
    public string Currency { get; init; }

    [JsonPropertyName("customer_email")]
    public string CustomerEmail { get; init; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; init; }

    [JsonPropertyName("iana_timezone")]
    public string IanaTimezone { get; init; }

    [JsonPropertyName("shop_owner")]
    public string ShopOwner { get; init; }

    [JsonPropertyName("money_format")]
    public string MoneyFormat { get; init; }

    [JsonPropertyName("money_with_currency_format")]
    public string MoneyWithCurrencyFormat { get; init; }

    [JsonPropertyName("weight_unit")]
    public string WeightUnit { get; init; }

    [JsonPropertyName("province_code")]
    public string? ProvinceCode { get; init; }

    [JsonPropertyName("taxes_included")]
    public bool TaxesIncluded { get; init; }

    [JsonPropertyName("auto_configure_tax_inclusivity")]
    public bool? AutoConfigureTaxInclusivity { get; init; }

    [JsonPropertyName("tax_shipping")]
    public bool? TaxShipping { get; init; }

    [JsonPropertyName("county_taxes")]
    public bool? CountyTaxes { get; init; }

    [JsonPropertyName("plan_display_name")]
    public string? PlanDisplayName { get; init; }

    [JsonPropertyName("plan_name")]
    public string? PlanName { get; init; }

    [JsonPropertyName("has_discounts")]
    public bool HasDiscounts { get; init; }

    [JsonPropertyName("has_gift_cards")]
    public bool HasGiftCards { get; init; }

    [JsonPropertyName("myshopify_domain")]
    public string MyShopifyDomain { get; init; }

    [JsonPropertyName("google_apps_domain")]
    public string? GoogleAppsDomain { get; init; }

    [JsonPropertyName("google_apps_login_enabled")]
    public bool? GoogleAppsLoginEnabled { get; init; }

    [JsonPropertyName("money_in_emails_format")]
    public string? MoneyInEmailsFormat { get; init; }

    [JsonPropertyName("money_with_currency_in_emails_format")]
    public string? MoneyWithCurrencyInEmailsFormat { get; init; }

    [JsonPropertyName("eligible_for_payments")]
    public bool EligibleForPayments { get; init; }

    [JsonPropertyName("requires_extra_payments_agreement")]
    public bool RequiresExtraPaymentsAgreement { get; init; }

    [JsonPropertyName("password_enabled")]
    public bool PasswordEnabled { get; init; }

    [JsonPropertyName("has_storefront")]
    public bool HasStorefront { get; init; }

    [JsonPropertyName("finances")]
    public bool Finances { get; init; }

    [JsonPropertyName("primary_location_id")]
    [JsonConverter(typeof(NumericStringConverter))]
    public string PrimaryLocationId { get; init; }

    [JsonPropertyName("checkout_api_supported")]
    public bool CheckoutApiSupported { get; init; }

    [JsonPropertyName("multi_location_enabled")]
    public bool MultiLocationEnabled { get; init; }

    [JsonPropertyName("setup_required")]
    public bool SetupRequired { get; init; }

    [JsonPropertyName("pre_launch_enabled")]
    public bool PreLaunchEnabled { get; init; }

    [JsonPropertyName("enabled_presentment_currencies")]
    public List<string> EnabledPresentmentCurrencies { get; init; }

    [JsonPropertyName("transactional_sms_disabled")]
    public bool TransactionalSmsDisabled { get; init; }

    [JsonPropertyName("marketing_sms_consent_enabled_at_checkout")]
    public bool MarketingSmsConsentEnabledAtCheckout { get; init; }
    
    [JsonPropertyName("access_token")]
    public string Accesstoken { get; init; }
    
    [JsonPropertyName("installation_status")]
    public bool InstallationStatus { get; init; }
    
    [JsonPropertyName("protection_percentage")]
    public decimal ProtectionPercentage { get; init; }
    
    [JsonPropertyName("minimum_protection_cost")]
    public decimal MinimumProtectionCost { get; init; }
}
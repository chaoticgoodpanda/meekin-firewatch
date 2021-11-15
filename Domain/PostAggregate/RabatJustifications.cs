using System;

namespace Domain.PostAggregate
{
    [Flags]
    public enum RabatJustifications
    {
        Racism = 0,
        ReligiousHatred = 1,
        Misogyny = 2,
        Violence = 3,
        SexualViolence = 4,
        RacePurity = 5,
        ReligiousPurity = 6,
        ComparisonToAnimals = 7,
        FakeNews = 8,
        Bribery = 9,
        ElectionFraud = 10,
        AntiInterracial = 11,
        FemalePurity = 12,
        FakeDeath = 13,
        CovidFraud = 14,
        ConsumerFraud = 15,
        DonationFraud = 16,
        AntiLGBTIQ = 17


    }
}

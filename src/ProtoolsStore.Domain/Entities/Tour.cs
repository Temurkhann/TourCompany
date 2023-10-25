using ProtoolsStore.Domain.Commons;
using ProtoolsStore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProtoolsStore.Domain.Entities;

public class Tour : Auditable, ILocalizationDescription, ILocalizationTitle
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Price { get; set; } = null!;
    public long AttachmentId { get; set; }
    public Attachment Attachment { get; set; } = null!;

    public string TitleUz { get; set; } = null!;
    public string TitleRu { get; set; } = null!;
    public string TitleEn { get; set; } = null!;

    public string DescriptionUz { get; set; } = null!;
    public string DescriptionRu { get; set; } = null!;
    public string DescriptionEn { get; set; } = null!;

    public Tour SetLocalization(Localization localization = Localization.Uz)
    {
        Title = localization switch
        {
            Localization.Ru => TitleRu,
            Localization.En => TitleEn,
            _ => TitleUz
        };

        Description = localization switch
        {
            Localization.Ru => DescriptionRu,
            Localization.En => DescriptionEn,
            _ => DescriptionUz
        };

        return this;
    }

    public string GetLocalizationName(Localization localization = Localization.Uz)
    {
        return localization switch
        {
            Localization.Ru => TitleRu,
            Localization.En => TitleEn,
            _ => TitleUz
        };
    }

    public string GetLocalizationDescription(Localization localization = Localization.Uz)
    {
        return localization switch
        {
            Localization.Ru => DescriptionRu,
            Localization.En => DescriptionEn,
            _ => DescriptionUz
        };
    }
}

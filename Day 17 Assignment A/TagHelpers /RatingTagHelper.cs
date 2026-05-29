using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomerFeedbackPortal.TagHelpers
{
    [HtmlTargetElement("rating-stars")]
    public class RatingTagHelper : TagHelper
    {
        public int Count { get; set; } = 5;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            string stars = "";

            for (int i = 1; i <= Count; i++)
            {
                stars += $"<span style='font-size:25px;color:gold;'>★</span>";
            }

            output.Content.SetHtmlContent(stars);
        }
    }
}

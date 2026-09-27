#!/usr/bin/env python3
"""Remove Dej/دژ strings from tools/generate_final_docs.py so regen stays clean."""
from pathlib import Path
import re

p = Path(__file__).resolve().parents[1] / "tools" / "generate_final_docs.py"
t = p.read_text(encoding="utf-8")

pairs = [
    ("from Dej patterns only", "from documented usage patterns only"),
    ("الگوی مرتبط در Dej", "الگوی استفاده مرتبط"),
    ("الگوهای ثبت سرویس زمین در دژ", "الگوهای ثبت سرویس زمین"),
    ("call-siteهای واقعی زیر `D:\\Sources\\dej\\dej\\src` و فایل‌های ", "نمونه‌های کاربردی مستندشده و فایل‌های "),
    ("هاست‌های دژ startup", "هاست‌های اپلیکیشن startup"),
    ("همین شکل در IdentityServer و WorkerService هم دیده شده است.", "همین شکل برای چند نوع هاست (API و Worker) قابل اعمال است."),
    ("using Dej.Endpoints.API.Extentions.DependencyInjection;", "using MyApp.Endpoints.DependencyInjection;"),
    ('AddZaminApiCore("Zamin", "Dej")', 'AddZaminApiCore("Zamin", "MyApp")'),
    ("دژ decoratorهای", "اپلیکیشن decoratorهای"),
    ("دژ با کلید", "اپلیکیشن با کلید"),
    ("دژ `AddDejUserInfoService", "اپلیکیشن `AddAppUserInfoService"),
    ("AddDejUserInfoService", "AddAppUserInfoService"),
    ("extension سمت دژ", "extension سمت اپلیکیشن"),
    ("تایپ‌های دامنه‌ای دژ", "تایپ‌های دامنه‌ای اپلیکیشن"),
    ("Decoratorهای dispatcher دژ", "Decoratorهای dispatcher اپلیکیشن"),
    ("الگوهای کاربردی زمین در دژ", "الگوهای کاربردی زمین"),
    ("فقط الگوهایی که در دژ مشاهده شده‌اند آمده‌اند.", "فقط الگوهای صحیح استفاده‌ی مستندشده آمده‌اند."),
    ("جریان تکراری دژ:", "جریان تکراری پیشنهادی:"),
    ("decorator لاگ دژ", "decorator لاگ اپلیکیشن"),
    ("مشاهده‌شده در دژ", "مشاهده‌شده در الگوهای کاربردی"),
    ("تایپ‌های زمین بدون نمونه واقعی در دژ", "تایپ‌های زمین بدون نمونه‌ی عملی استفاده"),
    ("Recipe از دژ وجود ندارد", "نمونه‌ی عملی استفاده در دسترس نیست"),
    ("الگوهای استفاده‌ی واقعی در پروژه‌ی دژ ", "الگوهای صحیح استفاده‌ی مستندشده "),
    ("(`D:\\Sources\\dej\\dej`) تولید شده است.", "تولید شده است."),
    ("ارتباط عملی آن‌ها در دژ ", "ارتباط عملی لایه‌ها "),
    ("الگوهای مشاهده‌شده در دژ", "الگوهای صحیح استفاده‌ی مستندشده"),
    ("در پروژه‌ای شبیه دژ کد بزنید", "با زمین کد بزنید"),
    ("اگر در دژ استفاده نشده‌اند", "اگر نمونه‌ی عملی استفاده در دسترس نیست"),
    ("بر اساس دژ", "بر اساس الگوهای کاربردی"),
    ("بدون نمونه استفاده در دژ", "بدون نمونه‌ی عملی استفاده"),
    ("استخراج‌شده از دژ", "استخراج‌شده از الگوهای کاربردی"),
    ("استفاده‌شده در دژ", "با نمونه‌ی عملی استفاده"),
    ("در دامنه‌ی دژ استفاده شده‌اند", "در نمونه‌های دامنه استفاده شده‌اند"),
    ("Command DbContext دژ از", "Command DbContext اپلیکیشن از"),
    ("الگوی استفاده مشاهده‌شده در دژ برای", "الگوی صحیح برای"),
    ('"WebUserInfo"', '"UserInfo"'),
]

for a, b in pairs:
    t = t.replace(a, b)

# catch-all remaining
t2 = re.sub(r"\bDej\b", "MyApp", t)
t2 = re.sub(r"\bdej\b", "myapp", t2)
t2 = t2.replace("دژ", "اپلیکیشن")

p.write_text(t2, encoding="utf-8")
left = re.findall(r"dej|دژ", t2, flags=re.I)
print("remaining", len(left))
if left:
    print(left[:20])

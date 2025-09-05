# Hướng dẫn import backlog vào GitHub Issues

## 1. Cài đặt công cụ

Mở terminal và cài đặt `github-csv-tools` qua npm:

```bash
npm install -g github-csv-tools
```

## 2. Chuẩn bị GitHub Token

- Tạo một [Personal Access Token (PAT)](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token) với quyền `repo`.
- Export token vào biến môi trường:

```bash
export GITHUB_TOKEN="your_github_token_here"
```

## 3. Import file CSV

Chạy lệnh sau trong thư mục gốc của project `gym-flow` (nơi có file `backlog.csv`):

```bash
github-csv-tools import --repo your_username/gym-flow --csv backlog.csv
```

**Lưu ý:** Thay `your_username` bằng username GitHub của bạn.
/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: '#3C50E0',
        secondary: '#1C2434',
        success: '#219653',
        danger: '#D34053',
        warning: '#F2994A',
        info: '#2F80ED',
        light: '#F1F5F9',
        dark: '#24303F',
        body: '#64748B',
        stroke: '#E2E8F0',
        gray: {
          DEFAULT: '#EFF4FB',
          2: '#F7F9FC',
          3: '#FAFAFA',
        },
        black: '#000000',
        white: '#FFFFFF',
      },
    },
  },
  plugins: [],
}

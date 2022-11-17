import { useI18n } from "vue-i18n"

export default function () {
  const { t } = useI18n()
  
  const dateRules = [val => !!val || t(error_text)]
  const textRules = [val => !!val || '* Camp obligatoriu', val => val.length > 2 || 'Nume prea scurt']

  return {
    dateRules,
    textRules
  }
}

